using API.Dtos.Request;
using API.Dtos.Response;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceVetController : ControllerBase
    {
        private readonly IServiceVetDomain _domain;
        private readonly IMapper _mapper;

        public ServiceVetController(IServiceVetDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ServiceVetCreateDto serviceVetCreateDto)
        {
            var result = _mapper.Map<ServiceVetCreateDto, ServiceVet>(serviceVetCreateDto);
            var isCreated = await _domain.CreateServiceVet(result);
            if (!isCreated) return BadRequest();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ServiceVetCreateDto serviceVetUpdate)
        {
            var result = _mapper.Map<ServiceVetCreateDto, ServiceVet>(serviceVetUpdate);
            var isCreated = await _domain.UpdateServiceVet(result);
            if (!isCreated) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _domain.DeleteServiceVet(id);
            if (!isDeleted) return NotFound();
            return NoContent();
        }

        [HttpGet("{id}/Vet/{vetId}")]
        public async Task<IActionResult> GetByIdAndVetId(int id, int vetId)
        {
            var result = await _domain.GetServiceVetById(id, vetId);
            if (result == null) return NotFound();
            var response = _mapper.Map<ServiceVet, ServiceVetResponseDto>(result);
            return Ok(response);
        }

        [HttpGet("Vet/{id}")]
        public async Task<IActionResult> GetAllByVetId(int id)
        {
            var result = await _domain.GetAllByVetId(id); 
            var response = _mapper.Map<List<ServiceVet>, List<ServiceVetResponseDto>>(result);
            return Ok(response);

        }
    }
}
