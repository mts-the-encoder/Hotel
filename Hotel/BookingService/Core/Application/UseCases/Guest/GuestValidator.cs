using Application.Guest.DTO;
using FluentValidation;

namespace Application.UseCases.Guest;

public class GuestValidator : AbstractValidator<GuestDTO>
{
    public GuestValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id could not be null");
        RuleFor(x => x.IdNumber).NotNull().MinimumLength(3).WithMessage("IdNumber must be at least 3 characters");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Insert a valid email");
        RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(3).WithMessage("Name must be at least 3 characters");
        RuleFor(x => x.Surname).NotNull().NotEmpty().MinimumLength(3).WithMessage("Name must be at least 3 characters");
    }
}