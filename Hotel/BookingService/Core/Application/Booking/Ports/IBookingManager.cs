using Application.Booking.Requests;
using Application.Booking.Responses;
using Application.Payment.Requests;
using Application.Payment.Responses;

namespace Application.Booking.Ports;

public interface IBookingManager
{
    Task<BookingResponse> Create(BookingRequest dto);
    Task<BookingResponse> GetById(int id);
    Task<PaymentResponse> PayForABooking(PaymentRequest paymentRequest);
}