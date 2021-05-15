using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdProject
{
    public class GetByIdProjectQueries: IRequest<ProjectDetailViewModel>
    {
        public int Id { get; set;}

        public GetByIdProjectQueries(int id)
        {
            this.Id = id;
        }
    }
}