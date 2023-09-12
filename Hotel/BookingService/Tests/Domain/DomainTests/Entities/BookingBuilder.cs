using Bogus;
using Domain.Entities;

namespace Tests.Entities;

public class BookingBuilder
{
    public static Booking Build()
    {
        return new Faker<Booking>()
            .RuleFor(x => x.Id, f => f.Random.Int())
            .RuleFor(x => x.PlacedAt, f => f.Date.Soon())
            .RuleFor(x => x.Start, f => f.Date.Recent())
            .RuleFor(x => x.End, f => f.Date.Future());
    }
}