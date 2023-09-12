using Application.Guest.DTO;
using AutoMapper;

namespace Application.Services.Mapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<GuestDTO, Domain.Entities.Guest>()
            .ForPath(dest => dest.Document.DocumentType, opt => opt.MapFrom(src => src.IdTypeCode))
            .ForPath(dest => dest.Document.IdNumber, opt => opt.MapFrom(src => src.IdNumber)).ReverseMap();
    }
}