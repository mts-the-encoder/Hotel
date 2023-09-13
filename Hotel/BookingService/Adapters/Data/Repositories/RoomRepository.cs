using Domain.Entities;
using Domain.Ports;

namespace Data.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly HotelDbContext _dbContext;
    public RoomRepository(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Room> GetByIdAsync(int id)
    {
        return await _dbContext.Rooms.FindAsync(id);
    }

    public async Task<int> SaveAsync(Room room)
    {
        _dbContext.Rooms.Add(room);
        await _dbContext.SaveChangesAsync();

        return room.Id;
    }
}