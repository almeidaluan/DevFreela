using System.Threading;
using System.Threading.Tasks;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.SaveComment
{
    public class SaveCommentCommandHandler : IRequestHandler<SaveCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext dBContext;

        public SaveCommentCommandHandler(DevFreelaDbContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<Unit> Handle(SaveCommentCommand request, CancellationToken cancellationToken)
        {
             var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await dBContext.ProjectComments.AddAsync(comment);
            await dBContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}