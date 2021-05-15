using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQueries, List<ProjectViewModel>>
    {

        private IProjectRepository projectRepository;

        public GetAllProjectsHandler(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }
        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQueries request, CancellationToken cancellationToken)
        {
            var projects = await this.projectRepository.GetAll();

            var projectsViewModel =  projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }
    }
}