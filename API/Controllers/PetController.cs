using API.Dtos.Request;
using API.Dtos.Response;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetDomain _petDomain;
        private readonly IMapper _mapper;
        public PetController(IPetDomain petDomain, IMapper mapper)
        {
            _petDomain = petDomain;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _petDomain.GetPetById(id);
            if (pet == null) return NotFound();
            var result = _mapper.Map<Pet, PetResponseDto>(pet);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PetCreateDto pet)
        {
            var result = _mapper.Map<PetCreateDto, Pet>(pet);
            var isCreated = await _petDomain.CreatePet(result);
            if (!isCreated) return NotFound();
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, isCreated);
        }
    }
}
