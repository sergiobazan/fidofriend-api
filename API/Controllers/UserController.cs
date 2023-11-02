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
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        public UserController(IUserDomain userDomain, IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userDomain.GetUserById(id);
            if (user == null) return NotFound();
            var result = _mapper.Map<User, UserResponseDto>(user);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserCreateDto user)
        {
            var result = _mapper.Map<UserCreateDto, User>(user);
            var isCreated = await _userDomain.CreateUser(result);
            if (!isCreated) return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateDto userUpdate)
        {
            var result = _mapper.Map<UserUpdateDto, User>(userUpdate);
            var isUpdated = await _userDomain.UpdateUser(id, result);
            if (!isUpdated) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _userDomain.DeleteUser(id);
            if (!isDeleted) return NotFound();
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLogin login)
        {
            var userFound = await _userDomain.GetUserLogin(login.Email, login.Password);
            if (userFound == null) return NotFound();
            var result = _mapper.Map<User, UserResponseDto>(userFound);
            return Ok(result);
        }

        [HttpGet("{id}/pets")]
        public async Task<IActionResult> GetPets(int id)
        {
            var pets = await _userDomain.GetPetsByUserId(id);
            var result = _mapper.Map<List<Pet>, List<PetResponseDto>>(pets);
            return Ok(result);
        }
    }
}
