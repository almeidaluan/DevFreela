using System;
using MediatR;

namespace DevFreela.Application.Commands.UserCreate
{
    public class UserCreateCommand : IRequest<int>
    {
        public string fullName { get; set;}
        public string email { get; set; }
        public DateTime birthDate { get; set;}
        public string Password { get; set;}
    }
}