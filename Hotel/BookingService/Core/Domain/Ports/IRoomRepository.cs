using Domain.Entities;

namespace Domain.Ports;

public interface IRoomRepository
{
    Task<Room> GetByIdAsync(int id);
    Task<int> SaveAsync(Room room);
}