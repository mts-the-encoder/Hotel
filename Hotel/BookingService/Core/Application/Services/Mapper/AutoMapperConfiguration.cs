using Application.Guest.DTO;
using Application.Room.DTO;
using AutoMapper;

namespace Application.Services.Mapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<GuestDTO, Domain.Entities.Guest>()
            .ForPath(dest => dest.Document.DocumentType, opt => opt.MapFrom(src => src.IdTypeCode))
            .ForPath(dest => dest.Document.IdNumber, opt => opt.MapFrom(src => src.IdNumber)).ReverseMap();

        CreateMap<RoomDTO, Domain.Entities.Room>()
            .ForPath(dest => dest.Price.Currency, opt => opt.MapFrom(src => src.Currency))
            .ForPath(dest => dest.Price.Value, opt => opt.MapFrom(src => src.Value)).ReverseMap();
    }
}