using Application.Booking.Dto;
using Application.Guest.Dto;
using Application.Room.Dto;
using AutoMapper;

namespace Application.Services.Mapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<GuestDto, Domain.Entities.Guest>()
            .ForPath(dest => dest.Document.DocumentType, opt => opt.MapFrom(src => src.IdTypeCode))
            .ForPath(dest => dest.Document.IdNumber, opt => opt.MapFrom(src => src.IdNumber)).ReverseMap();

        CreateMap<RoomDto, Domain.Entities.Room>()
            .ForPath(dest => dest.Price.Currency, opt => opt.MapFrom(src => src.Currency))
            .ForPath(dest => dest.Price.Value, opt => opt.MapFrom(src => src.Value)).ReverseMap();

        CreateMap<BookingDto, Domain.Entities.Booking>()
            .ForPath(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForPath(dest => dest.Room.Id, opt => opt.MapFrom(src => src.RoomId))
            .ForPath(dest => dest.Guest.Id, opt => opt.MapFrom(src => src.GuestId)).ReverseMap();
    }
}