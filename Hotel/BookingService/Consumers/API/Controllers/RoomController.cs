
using Application.Room.DTO;
using Application.Room.Requests;
using Application.Room.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RoomController : HotelBookingController
{
    private readonly IRoomManager _roomManager;
    public RoomController(IRoomManager roomManager)
    {
        this._roomManager = roomManager;
    }

    [HttpPost]
    public async Task<ActionResult<RoomDTO>> Create(RoomDTO dto)
    {
        var room = new RoomRequest(data: dto);

        await _roomManager.Create(room);

        return Created(string.Empty, room.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomDTO>> Get(int id)
    {
        var response = await _roomManager.GetById(id);

        return Ok(response.Data);
    }
}