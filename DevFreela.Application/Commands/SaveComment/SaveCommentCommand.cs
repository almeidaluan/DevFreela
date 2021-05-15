using MediatR;

namespace DevFreela.Application.Commands.SaveComment
{
    public class SaveCommentCommand : IRequest<Unit>
    {
        public string Content { get; set; }
        public int IdUser { get; set; }
        public int IdProject { get; set; }
    }
}