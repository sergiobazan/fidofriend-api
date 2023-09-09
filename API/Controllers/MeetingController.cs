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
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingDomain _domain;
        private readonly IMapper _mapper;

        public MeetingController(IMeetingDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MeetingCreateDto createDto)
        {
            var meeting = _mapper.Map<MeetingCreateDto, Meeting>(createDto);
            var result = await _domain.CreateMeeting(meeting);
            if (!result) return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = meeting.Id }, meeting);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _domain.DeleteMeeting(id);
            if (!isDeleted) return BadRequest();
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var meeting = await _domain.GetMeeting(id);
            if (meeting == null) return NotFound();
            var result = _mapper.Map<Meeting, MeetingResponseDto>(meeting);
            return Ok(result);
        }

        [HttpGet("Owner/{id}")]
        public async Task<IActionResult> GetByOwner(int id)
        {
            var meetings = await _domain.GetAllMeetingByClient(id);
            var result = _mapper.Map<IEnumerable<Meeting>, List<MeetingResponseDto>>(meetings);
            return Ok(result);
        }

        [HttpGet("Vet/{id}")]
        public async Task<IActionResult> GetByVet(int id)
        {
            var meetings = await _domain.GetAllMeetingByVet(id);
            var result = _mapper.Map<IEnumerable<Meeting>, List<MeetingResponseDto>>(meetings);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MeetingCreateDto meeting)
        {
            var isFinish = await _domain.FinishMeeting(id, meeting.Finish);
            if (!isFinish) return NotFound();
            return NoContent();
        }
    }
}
