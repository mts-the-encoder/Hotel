using Application.Guest.Dto;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using AutoMapper;
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

    public async Task<GuestResponse> Create(GuestRequest dto)
    {
        Validate(dto.Data);

        var guest = _mapper.Map<Domain.Entities.Guest>(dto.Data);

        await _repository.SaveAsync(guest);

        return new GuestResponse(data: dto.Data, success: true);
    }

    public async Task<GuestResponse> GetById(int id)
    {
        return await ExistsGuest(id);
    }

    private static void Validate(GuestDto guest)
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

        var guestDto = _mapper.Map<GuestDto>(guest);

        return new GuestResponse(data: guestDto,success: true);
    }
}