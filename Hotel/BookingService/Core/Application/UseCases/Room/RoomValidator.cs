using Application.Room.Dto;
using FluentValidation;

namespace Application.UseCases.Room;

public class RoomValidator : AbstractValidator<RoomDto>
{
    public RoomValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id could not be null");
        RuleFor(x => x.Level).NotNull().GreaterThanOrEqualTo(1).WithMessage("level must be greater than 0");
        RuleFor(x => x.Currency).NotNull().WithMessage("Insert a valid currency");
        RuleFor(x => x.Value).NotNull().GreaterThanOrEqualTo(100).WithMessage("Price must be at least 100");
        RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3).WithMessage("Name must be at least 3 characters");
    }
}