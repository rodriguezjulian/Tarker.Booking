using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword;

namespace Tarker.Booking.Application.Validators.User
{
    public class GetUserByUserNameAndPasswordValidator : AbstractValidator<(string,string)>
    {
        public GetUserByUserNameAndPasswordValidator()
        {
            RuleFor(x => x.Item2)
                        .NotEmpty()
                        .NotNull()
                        .WithMessage("El campo Password no puede estar vacio.")
                        .MaximumLength(10)
                        .WithMessage("El campo Password es de como maximo 50 caracteres")
                        ;
            RuleFor(x => x.Item1)
            .NotEmpty()
            .NotNull()
            .WithMessage("El campo Name no puede estar vacio.")
            .MaximumLength(50)
            .WithMessage("El campo Name es de como maximo 50 caracteres")
            ;
        }
    }
}
