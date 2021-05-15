using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository projectRepository;

        public FinishProjectCommandHandler(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            await projectRepository.FinishProjectAsync(request.id);

            return Unit.Value;
        }
    }
}