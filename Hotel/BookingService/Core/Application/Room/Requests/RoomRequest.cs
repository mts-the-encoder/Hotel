using Application.Guest.DTO;
using Application.Room.DTO;

namespace Application.Room.Requests;

public class RoomRequest
{
    public RoomDTO Data;
    public RoomRequest()
    {
    }

    public RoomRequest(RoomDTO data)
    {
        Data = data;
    }
}