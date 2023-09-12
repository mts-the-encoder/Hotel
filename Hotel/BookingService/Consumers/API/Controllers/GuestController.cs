using Application.Guest.DTO;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class GuestController : HotelBookingController
{
    private readonly IGuestManager _guestManager;
    public GuestController(IGuestManager ports)
    {
        _guestManager = ports;
    }

    [HttpPost]
    public async Task<ActionResult<GuestDTO>> Create(GuestDTO dto)
    {
        var guest = new GuestRequest(data: dto);

        await _guestManager.Create(guest);

        return Created(string.Empty, guest.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GuestDTO>> Get(int id)
    {
        var response = await _guestManager.GetById(id);

        return Ok(response.Data);
    }
}