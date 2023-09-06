using Bogus;
using Domain.Entities;

namespace Tests.Entities;

public class GuestBuilder
{
    public static Guest Build()
    {
        return new Faker<Guest>()
            .RuleFor(x => x.Id, f => f.Random.Int())
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.Surname, f => f.Person.LastName)
            .RuleFor(x => x.Email, f => f.Person.Email);
    }
}