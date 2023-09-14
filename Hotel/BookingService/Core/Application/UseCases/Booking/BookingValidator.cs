using Application.Booking.Dto;
using FluentValidation;

namespace Application.UseCases.Booking;

public class BookingValidator : AbstractValidator<BookingDto>
{
    public BookingValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id could not be null");
        RuleFor(x => x.Start).NotNull().WithMessage("DateStart not be null");
        RuleFor(x => x.End).NotNull().WithMessage("DateEnd not be null");
        RuleFor(x => x.PlacedAt).NotNull().NotEmpty().WithMessage("Place not be null");
    }
}