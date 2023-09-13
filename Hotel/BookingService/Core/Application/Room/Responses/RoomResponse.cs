using Application.Base;
using Application.Room.DTO;

namespace Application.Room.Responses;

public class RoomResponse : Response
{
    public RoomDTO Data;
    public RoomResponse()
    {
    }

    public RoomResponse(RoomDTO data, bool success)
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