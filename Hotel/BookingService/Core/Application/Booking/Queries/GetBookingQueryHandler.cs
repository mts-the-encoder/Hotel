using Application.Booking.Ports;
using Application.Booking.Responses;
using MediatR;

namespace Application.Booking.Queries;

public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingResponse>
{
    private readonly IBookingManager _bookingManager;
    public GetBookingQueryHandler(IBookingManager bookingManager)
    {
        _bookingManager = bookingManager;
    }

    public Task<BookingResponse> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        return _bookingManager.GetById(request.Id);
    }
}