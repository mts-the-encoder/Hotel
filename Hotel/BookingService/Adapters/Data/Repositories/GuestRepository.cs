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

    public Task<Guest> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> SaveAsync(Guest guest)
    {
        _dbContext.Guests.Add(guest);
        await _dbContext.SaveChangesAsync();

        return guest.Id;
    }
}