using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {

        public IProjectRepository projectRepository;

        public StartProjectCommandHandler(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async  Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            await projectRepository.StartProjectAsync(request.id);
            return Unit.Value;
        }
    }
}