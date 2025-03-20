using FluentValidation;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;

namespace Tarker.Booking.Application.Validators.Booking
{
    internal class CreateBookingValidator : AbstractValidator<CreateBookingModel>
    {
        public CreateBookingValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Type)
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.Code)
                .NotNull()
                .MaximumLength(50);
        }
    }
}
