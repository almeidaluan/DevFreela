using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommand : IRequest<Unit>
    {
        public int id { get; set; }

        public StartProjectCommand(int id)
        {
            this.id = id;
        }
    }
}