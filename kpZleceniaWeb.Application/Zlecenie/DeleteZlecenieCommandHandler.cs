using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Zlecenie.Command;
using MediatR;

namespace kpZleceniaWeb.Application.Zlecenie
{
    public class DeleteZlecenieCommandHandler : KpBaseHandler, IRequestHandler<DeleteZlecenieCommand>
    {
        public DeleteZlecenieCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task Handle(DeleteZlecenieCommand request, CancellationToken cancellationToken)
        {
            var zlecenieToDelete = _context.Zlecenie.FirstOrDefault(x => x.Id == request.ZlecenieId);

            if(zlecenieToDelete != null)
            {
                _context.Zlecenie.Remove(zlecenieToDelete);

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
