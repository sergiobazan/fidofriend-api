using API.Dtos.Request;
using AutoMapper;
using Infrastructure.Models;

namespace API.Mapper
{
    public class RequestToModel : Profile
    {
        public RequestToModel()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<PetCreateDto, Pet>();
        }
    }
}
