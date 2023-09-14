using Application.Guest.Dto;

namespace Application.Guest.Requests;

public class GuestRequest
{
    public GuestDto Data;
    public GuestRequest() { }

    public GuestRequest(GuestDto data)
    {
        Data = data;
    }
}