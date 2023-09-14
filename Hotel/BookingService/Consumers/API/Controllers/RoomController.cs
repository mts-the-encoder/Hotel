
using Application.Room.Dto;
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
    public async Task<ActionResult<RoomDto>> Create(RoomDto Dto)
    {
        var room = new RoomRequest(data: Dto);

        await _roomManager.Create(room);

        return Created(string.Empty, room.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomDto>> Get(int id)
    {
        var response = await _roomManager.GetById(id);

        return Ok(response.Data);
    }
}