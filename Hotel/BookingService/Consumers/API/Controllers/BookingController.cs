using Application.Booking.Dto;
using Application.Booking.Ports;
using Application.Booking.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BookingController : HotelBookingController
{
    private readonly IBookingManager _bookingManager;
    public BookingController(IBookingManager bookingManager)
    {
        _bookingManager = bookingManager;
    }

    [HttpPost]
    public async Task<ActionResult<BookingDto>> Create(BookingDto Dto)
    {
        var booking = new BookingRequest(data: Dto);

        await _bookingManager.Create(booking);

        return Created(string.Empty,booking.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookingDto>> Get(int id)
    {
        var response = await _bookingManager.GetById(id);

        return Ok(response.Data);
    }
}