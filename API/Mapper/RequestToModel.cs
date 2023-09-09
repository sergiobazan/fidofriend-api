using API.Dtos.Request;
using API.Dtos.Response;
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
            CreateMap<ClinicalRecordCreateDto, ClinicalRecord>();
            CreateMap<ServiceCreateDto, Service>();
            CreateMap<ServiceVetCreateDto, ServiceVet>();
            CreateMap<MeetingCreateDto, Meeting>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
