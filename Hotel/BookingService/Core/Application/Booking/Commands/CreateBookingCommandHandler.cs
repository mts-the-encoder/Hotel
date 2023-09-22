using Application.Booking.Ports;
using Application.Booking.Responses;
using MediatR;

namespace Application.Booking.Commands;

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BookingResponse>
{
    private readonly IBookingManager _bookingManager;
    public CreateBookingCommandHandler(IBookingManager bookingManager)
    {
        _bookingManager = bookingManager;
    }

    public Task<BookingResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        return _bookingManager.Create(request.BookingDto);
    }
}