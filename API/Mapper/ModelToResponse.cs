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
            CreateMap<Pet, PetResponseDto>();
            CreateMap<ClinicalRecord, ClinicalRecordResponseDto>();
            CreateMap<Service, ServiceResponseDto>();
            CreateMap<ServiceVet, ServiceVetResponseDto>();
            CreateMap<Meeting, MeetingResponseDto>();
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
