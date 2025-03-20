using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;

namespace Tarker.Booking.Application.Validators.User
{
    internal class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdateUserPasswordValidator()
        {


            RuleFor(x => x.Id)
                    .GreaterThan(0)
                    .WithMessage("El Id ingresado debe ser valido.")
                    ;
            RuleFor(x => x.UserPassword)
                        .NotEmpty()
                        .NotNull()
                        .WithMessage("El campo Password no puede estar vacio.")
                        .MaximumLength(10)
                        .WithMessage("El campo Password es de como maximo 50 caracteres")
                        ;
        }
    }
}