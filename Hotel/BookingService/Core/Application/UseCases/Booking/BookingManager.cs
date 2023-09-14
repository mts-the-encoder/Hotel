using Application.Booking.Dto;
using Application.Booking.Ports;
using Application.Booking.Requests;
using Application.Booking.Responses;
using Application.Room.Responses;
using AutoMapper;
using Domain.Ports;

namespace Application.UseCases.Booking;

public class BookingManager : IBookingManager
{
    private readonly IBookingRepository _repository;
    private readonly IMapper _mapper;

    public BookingManager(IBookingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BookingResponse> Create(BookingRequest dto)
    {
        Validate(dto.Data);

        var booking = _mapper.Map<Domain.Entities.Booking>(dto.Data);

        await _repository.SaveAsync(booking);

        return new BookingResponse(data: dto.Data, success: true);
    }

    public async Task<BookingResponse> GetById(int id)
    {
        return await ExistsBooking(id);
    }

    private static void Validate(BookingDto booking)
    {
        var validator = new BookingValidator();
        var response = validator.Validate(booking);

        if (!response.IsValid)
        {
            var error = response.Errors.Select(x => x.ErrorMessage).FirstOrDefault();
            throw new FluentValidation.ValidationException(error);
        }
    }

    private async Task<BookingResponse> ExistsBooking(int id)
    {
        var booking = await _repository.GetByIdAsync(id);

        if (booking is null)
            throw new KeyNotFoundException($"Booking with id: {id} not found");

        var bookingDto = _mapper.Map<BookingDto>(booking);

        return new BookingResponse(data: bookingDto,success: true);
    }
}