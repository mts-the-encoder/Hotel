using Application.Guest.Dto;
using Application.Room.Dto;

namespace Application.Room.Requests;

public class RoomRequest
{
    public RoomDto Data;
    public RoomRequest()
    {
    }

    public RoomRequest(RoomDto data)
    {
        Data = data;
    }
}