using Application.Guest.DTO;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using AutoMapper;
using Data.Exceptions;
using Domain.Ports;

namespace Application.UseCases.Guest;

public class GuestManager : IGuestManager
{
    private readonly IGuestRepository _repository;

    private readonly IMapper _mapper;

    public GuestManager(IGuestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GuestResponse> Create(GuestRequest request)
    {
        Validate(request.Data);

        var guest = _mapper.Map<Domain.Entities.Guest>(request.Data);

        await _repository.SaveAsync(guest);

        return new GuestResponse(data: request.Data, success: true);
    }

    public async Task<GuestResponse> GetById(int id)
    {
        return await ExistsGuest(id);
    }

    private static void Validate(GuestDTO guest)
    {
        var validator = new GuestValidator();
        var response = validator.Validate(guest);

        if (!response.IsValid)
        {
            var error = response.Errors.Select(x => x.ErrorMessage).FirstOrDefault();
            throw new FluentValidation.ValidationException(error);
        }
    }

    private async Task<GuestResponse> ExistsGuest(int id)
    {
        var guest = await _repository.GetByIdAsync(id);

        if (guest is null) throw new KeyNotFoundException($"Guest with id: {id} not found");

        var guestDto = _mapper.Map<GuestDTO>(guest);

        return new GuestResponse(data: guestDto,success: true);
    }
}