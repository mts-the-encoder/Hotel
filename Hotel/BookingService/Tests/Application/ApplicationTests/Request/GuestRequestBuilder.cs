using Application.Guest.Dto;
using Bogus;

namespace ApplicationTests.Request;

public class GuestRequestBuilder
{
    public static GuestDto Build()
    {
        return new Faker<GuestDto>()
            .RuleFor(x => x.Id, f => f.Random.Int(1, 1000))
            .RuleFor(x => x.IdNumber, f => f.Random.Word())
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.Surname, f => f.Person.LastName)
            .RuleFor(x => x.Email, f => f.Person.Email);
    }
}