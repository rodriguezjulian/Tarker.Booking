using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Custommer.Commands.CreateCustomer;

namespace Tarker.Booking.Application.Validators.Customer
{
    internal class UpdateCustomerValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotNull()
                .GreaterThan(1);

            RuleFor(x => x.FullName)
                 .NotEmpty()
                 .NotNull()
                 .MaximumLength(50);

            RuleFor(x => x.DocumentNumber)
                .NotEmpty()
                .NotNull()
                .Length(8);
        }
    }
}
