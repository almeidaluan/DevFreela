using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.UserCreate
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, int>
    {
        private readonly IUserRepository userRepository;

        public UserCreateCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<int> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.fullName,request.email,request.birthDate);
            await userRepository.CreateUser(user);
            return user.Id;
        }
    }
}