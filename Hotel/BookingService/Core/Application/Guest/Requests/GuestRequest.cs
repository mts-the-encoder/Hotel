using Application.Guest.DTO;

namespace Application.Guest.Requests;

public class GuestRequest
{
    public GuestDTO Data;
    public GuestRequest() { }

    public GuestRequest(GuestDTO data)
    {
        Data = data;
    }
}