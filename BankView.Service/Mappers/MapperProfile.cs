using AutoMapper;
using BankView.Domain.Entities;
using BankView.Service.DTOs;
using BankView.Service.DTOs.DailyCosts;

namespace BankView.Service.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserForResultDto>().ReverseMap();
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();

            CreateMap<DailyCost, DailyCostForResultDto>().ReverseMap();
            CreateMap<DailyCost, DailyCostForCreationDto>().ReverseMap();
            CreateMap<DailyCost, DailyCostForUpdateDto>().ReverseMap();
        }
    }
}
