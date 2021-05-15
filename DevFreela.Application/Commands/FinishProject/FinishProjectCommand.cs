using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommand : IRequest<Unit>
    {
        public int id { get; set;}
        public FinishProjectCommand(int id)
        {
            this.id = id;
        }
    }
}