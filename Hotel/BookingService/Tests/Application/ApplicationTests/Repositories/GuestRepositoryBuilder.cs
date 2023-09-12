using Domain.Ports;
using Moq;

namespace Tests.Repositories;

public class GuestRepositoryBuilder
{
    private static GuestRepositoryBuilder _instance;
    private readonly Mock<IGuestRepository> _repository;

    private GuestRepositoryBuilder()
    {
        _repository ??= new Mock<IGuestRepository>();
    }

    public static GuestRepositoryBuilder Instance()
    {
        _instance = new GuestRepositoryBuilder();
        return _instance;
    }

    public IGuestRepository Build()
    {
        return _repository.Object;
    }
}