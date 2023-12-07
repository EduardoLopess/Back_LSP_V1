using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaingnDonationController : ControllerBase
    {
        private readonly ICampaingnDonationRepository _campaingnDonationRepository;
        private readonly IMapper _mapper;
        public CampaingnDonationController(ICampaingnDonationRepository campaingnDonationRepository, IMapper mapper)
        {
            _campaingnDonationRepository = campaingnDonationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var campaingnDonation = await _campaingnDonationRepository.GetAllAsync();
            var campaingnDonationDTO = _mapper.Map<IList<CampaingnDonationDTO>>(campaingnDonation);

            foreach (var item in campaingnDonationDTO)
            {
                item.TypeMaterialTypeDescription = item.MaterialType
                    .GetDescription();
                 item.PriorityDonationDescription = item.PriorityDonation
                    .GetDescription();
            }

            return
                HttpMessageOk(campaingnDonationDTO);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var campaingnDonation = await _campaingnDonationRepository.GetByIdAsync(id);
            if(campaingnDonation == null) return NotFound();

            var campaingnDonationDTO = _mapper.Map<CampaingnDonationDTO>(campaingnDonation);
            campaingnDonationDTO.TypeMaterialTypeDescription = campaingnDonationDTO
                .MaterialType.GetDescription();
            
            campaingnDonationDTO.PriorityDonationDescription = campaingnDonationDTO
                .PriorityDonation.GetDescription();
            
            return
                HttpMessageOk(campaingnDonationDTO);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CampaingnDonationViewModel createModel)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var campaingnDonation = _mapper.Map<CampaingnDonation>(createModel);
            campaingnDonation.Address = _mapper.Map<Address>(createModel.AddressViewModel);

            await _campaingnDonationRepository.CreateAsync
            (
                campaingnDonation, 
                _mapper.Map<Address>(createModel.AddressViewModel)
            );

            var campaingnDonationDTO = _mapper.Map<CampaingnDonationDTO>(campaingnDonation);

            return HttpMessageOk(campaingnDonationDTO);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CampaingnDonationViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            var campaingnDonation = _mapper.Map<CampaingnDonation>(model);
            campaingnDonation.Id = id;
            await _campaingnDonationRepository.UpdateAsync(campaingnDonation);

            var campaingnDonationDTO = _mapper.Map<CampaingnDonationDTO>(campaingnDonation);
            return
                HttpMessageOk(campaingnDonationDTO);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var campaingnDonation = await _campaingnDonationRepository.GetByIdAsync(id);
            if(campaingnDonation == null) return NotFound();

            await _campaingnDonationRepository.DeleteAsync(id);
            return
                HttpMessageOk($"Campanha de ID: {id}. DELETADA!");
        }
        




        private IActionResult HttpMessageOk(dynamic data = null)
        {
            if (data == null)
                return NoContent();
            else
                return Ok(new { data });
        }

        private IActionResult HttpMessageError(string message = "")
        {
            return BadRequest(new { message });
        }
    }
}