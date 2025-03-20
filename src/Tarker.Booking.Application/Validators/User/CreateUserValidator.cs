using FluentValidation;
using Tarker.Booking.Application.DataBase.User.Commands.CreateUser;

namespace Tarker.Booking.Application.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("El campo First Name no puede estar vacio.")
                .MaximumLength(50)
                .WithMessage("El campo First Name es de como maximo 50 caracteres")
                ;

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage("El campo Last Name no puede estar vacio.")
                .MaximumLength(50)
                .WithMessage("El campo Last Name es de como maximo 50 caracteres")
                ;

            RuleFor(x => x.UserName)
                .NotEmpty()
                .NotNull()
                .WithMessage("El campo User Name no puede estar vacio.")
                .MaximumLength(50)
                .WithMessage("El campo User Name es de como maximo 50 caracteres")
                ;

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("El campo Password no puede estar vacio.")
                .MaximumLength(10)
                .WithMessage("El campo Password es de como maximo 50 caracteres")
                ;
        }
    }
}
