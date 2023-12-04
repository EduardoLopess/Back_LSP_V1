using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public AddressController(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var address = await _addressRepository.GetAllAsync();
            var addressDTO = _mapper.Map<IList<AddressDTO>>(address);

            return
                HttpMessageOk(addressDTO);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address == null) return NotFound();
            
            var addressDTO = _mapper.Map<AddressDTO>(address);
            return
                HttpMessageOk(addressDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddressViewModel addressModel, int UserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados incorretos");
            }
            var address = _mapper.Map<Address>(addressModel);

            try
            {
                await _addressRepository.CreateAsync(address);
                return Ok("Endereço criado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
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