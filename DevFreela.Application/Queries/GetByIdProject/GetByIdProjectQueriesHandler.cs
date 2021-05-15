using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetByIdProject
{
    public class GetByIdProjectQueriesHandler : IRequestHandler<GetByIdProjectQueries, ProjectDetailViewModel>
    {

        private readonly IProjectRepository projectRepository;
        
        public GetByIdProjectQueriesHandler(IProjectRepository projectRepository)
        {
            this.projectRepository=  projectRepository;
        }
        public async Task<ProjectDetailViewModel> Handle(GetByIdProjectQueries request, CancellationToken cancellationToken)
        {

           var project = await this.projectRepository.GetByIdAsync(request.Id);

            if(project == null) return null;

            var projectsDetailViewModel = new ProjectDetailViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.StartedAt,
                project.FinishedAt,
                project.TotalCost,
                project.Client.FullName,
                project.Freelancer.FullName
            );
            
            return projectsDetailViewModel;
        }
    }
}