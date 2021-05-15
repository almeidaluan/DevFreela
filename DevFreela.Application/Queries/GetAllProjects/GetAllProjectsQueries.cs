using System.Collections.Generic;
using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueries : IRequest<List<ProjectViewModel>>
    {
        public string Query { get; set;}

        public GetAllProjectsQueries(string query)
        {
            this.Query = query;
        }
    }
}