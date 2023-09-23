using Application.Booking.Commands;
using Application.Booking.Dto;
using Application.Booking.Ports;
using Application.Booking.Queries;
using Application.Booking.Requests;
using Application.Booking.Responses;
using Application.Payment.Requests;
using Application.Payment.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BookingController : HotelBookingController
{
    private readonly IBookingManager _bookingManager;
    private readonly IMediator _mediator;
    public BookingController(IBookingManager bookingManager, IMediator mediator)
    {
        _bookingManager = bookingManager;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<BookingResponse>> Create(BookingDto booking)
    {
        var command = new CreateBookingCommand
        {
            BookingDto = booking
        };

        var response = await _mediator.Send(command);

        return Created(string.Empty, response.Data);
    }

    [HttpPost("{bookingId}Pay")]
    public async Task<ActionResult<PaymentResponse>> Create(PaymentRequest request, int bookingId)
    {
        request.BookingId = bookingId;
        var response = await _bookingManager.PayForABooking(request);

        return Created(string.Empty, response.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookingDto>> Get(int id)
    {
        var query = new GetBookingQuery
        {
            Id = id
        };

        var response = await _mediator.Send(query);
         
        return Ok(response.Data);
    }
}