using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.User.Command;
using MediatR;

namespace kpZleceniaWeb.Application.User
{
    public class DeleteUserCommandHandler : KpBaseHandler, IRequestHandler<DeleteUserCommand>
    {
        public DeleteUserCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == request.UserId);

            if(user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
