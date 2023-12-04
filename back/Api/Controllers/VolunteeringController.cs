using AutoMapper;
using Data.Repository;
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
    public class VolunteeringController : ControllerBase
    {
        private readonly IVolunteeringRepository _volunteeringRepository;
        private readonly IMapper _mapper;
        public VolunteeringController(IVolunteeringRepository volunteeringRepository, IMapper mapper)
        {
            _volunteeringRepository = volunteeringRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var volunteering = await _volunteeringRepository.GetAllAsync();
            var volunteeringDTO = _mapper.Map<IList<VolunteeringDTO>>(volunteering);
            foreach (var item in volunteeringDTO)
            {
                item.TypeVolunteeringDescription = item.TypeVolunteering
                    .GetDescription();
            }
            return
                HttpMessageOk(volunteeringDTO);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var volunteering = await _volunteeringRepository.GetByIdAsync(id);
            if (volunteering == null) return NotFound();

            var volunteeringDTO = _mapper.Map<VolunteeringDTO>(volunteering);
            volunteeringDTO.TypeVolunteeringDescription = volunteeringDTO
                .TypeVolunteering.GetDescription();

            return
                HttpMessageOk(volunteeringDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] VolunteeringViewModel createModel)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var volunteering = _mapper.Map<Volunteering>(createModel);

            volunteering.Address = _mapper.Map<Address>(createModel.AddressViewModels);

            volunteering.Responsibilities = createModel.Responsibilities;
            volunteering.Benefits = createModel.Benefits;

            // Ajuste o método CreateAsync para aceitar um único endereço
            await _volunteeringRepository.CreateAsync(volunteering, createModel.Responsibilities, createModel.Benefits, _mapper.Map<Address>(createModel.AddressViewModels));

            var volunteeringDTO = _mapper.Map<VolunteeringDTO>(volunteering);
            return HttpMessageOk(volunteeringDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VolunteeringViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");
            var volunteering = _mapper.Map<Volunteering>(model);
            volunteering.Id = id;
            await _volunteeringRepository.UpdateAsync(volunteering);

            var volunteeringDTO = _mapper.Map<VolunteeringDTO>(volunteering);
            return
                HttpMessageOk(volunteeringDTO);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var volunteering = await _volunteeringRepository.GetByIdAsync(id);
            if(volunteering == null) return NotFound();

            await _volunteeringRepository.DeleteAsync(id);
            return
                HttpMessageOk($"Volunteering ID: {id}. DELETADO!");
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