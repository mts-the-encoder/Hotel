using Application.Booking.Dto;

namespace Application.Booking.Requests;

public class BookingRequest
{
    public BookingDto Data;
    public BookingRequest()
    {
    }

    public BookingRequest(BookingDto data)
    {
        Data = data;
    }
}