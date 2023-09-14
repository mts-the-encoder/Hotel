using Application.Guest.Dto;
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
    public async Task<ActionResult<GuestDto>> Create(GuestDto Dto)
    {
        var guest = new GuestRequest(data: Dto);

        await _guestManager.Create(guest);

        return Created(string.Empty, guest.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GuestDto>> Get(int id)
    {
        var response = await _guestManager.GetById(id);

        return Ok(response.Data);
    }
}