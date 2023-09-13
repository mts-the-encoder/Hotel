using Application.Room.Requests;
using Application.Room.Responses;

namespace Application.Room.Ports;

public interface IRoomManager
{
   Task<RoomResponse> Create(RoomRequest dto);
   Task<RoomResponse> GetById(int id);
}