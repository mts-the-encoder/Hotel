using Application.Base;
using Application.Room.Dto;

namespace Application.Room.Responses;

public class RoomResponse : Response
{
    public RoomDto Data;
    public RoomResponse()
    {
    }

    public RoomResponse(RoomDto data, bool success)
    {
        Data = data;
        Success = success;
    }

    public RoomResponse(bool success, ErrorCodes errorCode, string message) : this()
    {
        Success = success;
        ErrorCode = errorCode;
        Message = message;
    }
}