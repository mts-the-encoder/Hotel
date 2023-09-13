using Application.Base;
using Application.Guest.DTO;

namespace Application.Guest.Responses;

public class GuestResponse : Response
{
    public GuestDTO Data;
    public GuestResponse()
    {
    }

    public GuestResponse(GuestDTO data,bool success)
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