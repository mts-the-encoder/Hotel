using Bogus;
using Domain.Entities;

namespace DomainTests.Entities;

public class RoomBuilder
{
    public static Room Build()
    {
        return new Faker<Room>()
            .RuleFor(x => x.Id, f => f.Random.Int())
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.Level, f => f.Random.Int())
            .RuleFor(x => x.InMaintenance, f => f.Random.Bool())
            .RuleFor(x => x.IsAvailable, f => f.Random.Bool())
            .RuleFor(x => x.HasGuest,f => f.Random.Bool());
    }
}