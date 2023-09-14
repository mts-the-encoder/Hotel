using Domain.Entities;

namespace Domain.Ports;

public interface IBookingRepository
{
    Task<Booking> GetByIdAsync(int id);
    Task<int> SaveAsync(Booking booking);
}