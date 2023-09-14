using Application.Base;
using Application.Guest.Dto;

namespace Application.Guest.Responses;

public class GuestResponse : Response
{
    public GuestDto Data;
    public GuestResponse()
    {
    }

    public GuestResponse(GuestDto data,bool success)
    {
        Data = data;
        Success = success;
    }

    public GuestResponse(bool success,ErrorCodes errorCode,string message) : this()
    {
        Success = success;
        ErrorCode = errorCode;
        Message = message;
    }
}