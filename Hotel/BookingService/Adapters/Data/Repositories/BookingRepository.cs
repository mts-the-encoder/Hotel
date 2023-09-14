using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly HotelDbContext _dbContext;
    public BookingRepository(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Booking> GetByIdAsync(int id)
    {
        return await _dbContext.Bookings
            .Include(b => b.Guest)
            .Include(b => b.Room)
            .Where(x => x.Id == id).FirstAsync();
    }

    public async Task<int> SaveAsync(Booking booking)
    {
        var room = _dbContext.Rooms.FirstOrDefault(x => x.Id == booking.Room.Id);
        var guest = _dbContext.Guests.FirstOrDefault(x => x.Id == booking.Room.Id);


        booking.Guest = guest;
        booking.Room = room;
        await _dbContext.Bookings.AddAsync(booking);
        await _dbContext.SaveChangesAsync();
        return booking.Id;
    }
}