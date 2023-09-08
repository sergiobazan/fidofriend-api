using API.Dtos.Response;
using AutoMapper;
using Infrastructure.Models;

namespace API.Mapper
{
    public class ModelToResponse : Profile
    {
        public ModelToResponse()
        {
            CreateMap<User, UserResponseDto>();
        }
    }
}
