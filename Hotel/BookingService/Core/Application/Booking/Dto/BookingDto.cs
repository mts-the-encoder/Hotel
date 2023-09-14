using Application.Guest.Dto;
using Application.Room.Dto;

namespace Application.Booking.Dto;

public class BookingDto
{
    public int Id { get; set; }
    public DateTime PlacedAt { get; set; } = DateTime.UtcNow;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
    public int Status { get; } = 1;
}