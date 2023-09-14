using Application.Base;
using Application.Booking.Dto;

namespace Application.Booking.Responses;

public class BookingResponse : Response
{
    public BookingDto Data;
    public BookingResponse()
    {
    }

    public BookingResponse(BookingDto data, bool success)
    {
        Data = data;
        Success = success;
    }

    public BookingResponse(bool success, ErrorCodes errorCode, string message) : this()
    {
        Success = success;
        ErrorCode = errorCode;
        Message = message;
    }
}