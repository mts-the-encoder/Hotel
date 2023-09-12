using Domain.Entities;
using Domain.Ports;

namespace Data.Repositories;

public class GuestRepository : IGuestRepository
{
    private readonly HotelDbContext _dbContext;
    public GuestRepository(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guest> GetByIdAsync(int id)
    {
        return await _dbContext.Guests.FindAsync(id);
    }

    public async Task<int> SaveAsync(Guest guest)
    {
        _dbContext.Guests.Add(guest);
        await _dbContext.SaveChangesAsync();

        return guest.Id;
    }
}