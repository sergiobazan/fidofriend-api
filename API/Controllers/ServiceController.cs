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
    public class ServiceController : ControllerBase
    {
        private readonly IServiceDomain _domain;
        private readonly IMapper _mapper;

        public ServiceController(IServiceDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var services = await _domain.GetServices();
            var result = _mapper.Map<List<Service>, List<ServiceResponseDto>>(services);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _domain.GetService(id);
            if (service == null) return NotFound();
            var result = _mapper.Map<Service, ServiceResponseDto>(service);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ServiceCreateDto service)
        {
            var result = _mapper.Map<ServiceCreateDto, Service>(service);
            var isCreated = await _domain.CreateService(result);
            if (!isCreated) return BadRequest();
            return Ok(result);
        }
    }
}
