using Application.Guest.Requests;
using Application.Guest.Responses;

namespace Application.Guest.Ports;

public interface IGuestManager
{
    Task<GuestResponse> Create(GuestRequest dto);
    Task<GuestResponse> GetById(int id);
}