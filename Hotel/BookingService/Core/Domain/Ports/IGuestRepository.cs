using Domain.Entities;

namespace Domain.Ports;

public interface IGuestRepository
{
    Task<Guest> GetByIdAsync(int id);
    Task<int> SaveAsync(Guest guest);
}