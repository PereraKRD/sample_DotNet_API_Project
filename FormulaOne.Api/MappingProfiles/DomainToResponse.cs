using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.DTOs.Responses;

namespace FormulaOne.Api.MappingProfiles;

public class DomainToResponse : Profile
{

    public DomainToResponse()
    {
        CreateMap<Achievement, DriverAchievementResponse>()
            .ForMember(dest => dest.RaceWins,
                opt => opt
                    .MapFrom(src => src.RaceWins))
            ;
        //from diver to GetDriverResponse
        CreateMap<Driver, GetDriverResponse>()
            .ForMember(dest => dest.DriverId,opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName,
                opt => opt
                    .MapFrom(src => $"{src.FirstName} {src.LastName}"))
            ;
    }
    
}