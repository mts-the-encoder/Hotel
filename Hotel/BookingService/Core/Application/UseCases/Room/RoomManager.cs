using Application.Room.Dto;
using Application.Room.Ports;
using Application.Room.Requests;
using Application.Room.Responses;
using AutoMapper;
using Domain.Ports;

namespace Application.UseCases.Room;

public class RoomManager : IRoomManager
{
    private readonly IRoomRepository _repository;
    private readonly IMapper _mapper;
    public RoomManager(IRoomRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RoomResponse> Create(RoomRequest dto)
    {
        Validate(dto.Data);

        var guest = _mapper.Map<Domain.Entities.Room>(dto.Data);

        await _repository.SaveAsync(guest);

        return new RoomResponse(data: dto.Data,success: true);
    }

    public async Task<RoomResponse> GetById(int id)
    {
        return await ExistsRoom(id);
    }

    private static void Validate(RoomDto room)
    {
        var validator = new RoomValidator();
        var response = validator.Validate(room);

        if (!response.IsValid)
        {
            var error = response.Errors.Select(x => x.ErrorMessage).FirstOrDefault();
            throw new FluentValidation.ValidationException(error);
        }
    }

    private async Task<RoomResponse> ExistsRoom(int id)
    {
        var room = await _repository.GetByIdAsync(id);

        if (room is null)
            throw new KeyNotFoundException($"Room with id: {id} not found");

        var roomDto = _mapper.Map<RoomDto>(room);

        return new RoomResponse(data: roomDto,success: true);
    }
}