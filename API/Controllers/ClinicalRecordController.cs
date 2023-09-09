using API.Dtos.Request;
using AutoMapper;
using Domain.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicalRecordController : ControllerBase
    {
        private readonly IClinicalRecordDomain _domain;
        private readonly IMapper _mapper;
        public ClinicalRecordController(IClinicalRecordDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClinicalRecordCreateDto recordCreateDto)
        {
            var result = _mapper.Map<ClinicalRecordCreateDto, ClinicalRecord>(recordCreateDto);
            var isCreated = await _domain.CreateClinicalRecord(result);
            if (!isCreated) return BadRequest();
            return Created($"/api/ClinicalRecord/pet/{recordCreateDto.PetId}", result);
        }

        [HttpGet("pet/{id}")]
        public async Task<IActionResult> GetByPetId(int id)
        {
            return Ok(await _domain.GetClinicalRecordByPetId(id));
        }
    }
}
