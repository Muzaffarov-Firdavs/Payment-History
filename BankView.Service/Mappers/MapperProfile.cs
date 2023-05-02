using AutoMapper;
using BankView.Domain.Entities;
using BankView.Service.DTOs;

namespace BankView.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserForResultDto>().ReverseMap();
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();
        }
    }
}
