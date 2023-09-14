using Application.Booking.Requests;
using Application.Booking.Responses;

namespace Application.Booking.Ports;

public interface IBookingManager
{
    Task<BookingResponse> Create(BookingRequest dto);
    Task<BookingResponse> GetById(int id);
}