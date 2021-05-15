using System.Collections.Generic;
using System.Text.RegularExpressions;
using DevFreela.Application.Commands.UserCreate;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class UserCreateCommandValidator : AbstractValidator<List<UserCreateCommand>>
    {

        public UserCreateCommandValidator()
        {
            // RuleFor(p => p.email)
            //     .EmailAddress()
            //     .WithMessage("Email nao valido!");

            RuleForEach(x => x).ChildRules(orders => {
                orders.RuleFor(x => x.email).EmailAddress();
            });

            // RuleFor(p => p.Password)
            //     .Must(ValidPassword)
            //     .WithMessage("Senha deve conter pelo menos 8 caracteres,um numero, uma letra maiuscula,uma minuscula e uma caractere especial");


            // RuleFor(p => p.fullName)
            //     .NotNull()
            //     .WithMessage("Nome nao pode ser nulo !");

            // RuleFor(p => p.fullName)
            //     .NotEmpty()
            //     .WithMessage("Nome nao pode ser em branco !");
                
                


        }

        public bool ValidPassword(string password){
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(password);
        }
    }
}