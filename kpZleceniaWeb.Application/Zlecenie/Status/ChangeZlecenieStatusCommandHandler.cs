using kpZleceniaWeb.Application.Common.Exceptions;
using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Zlecenie.Status.Command;
using MediatR;

namespace kpZleceniaWeb.Application.Zlecenie.Status
{
    public class ChangeZlecenieStatusCommandHandler : KpBaseHandler, IRequestHandler<ChangeZlecenieStatusCommand>
    {
        public ChangeZlecenieStatusCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task Handle(ChangeZlecenieStatusCommand request, CancellationToken cancellationToken)
        {
            var zlecenieToEdit = _context.Zlecenie.FirstOrDefault(x => x.Id == request.ZlecenieId);

            var newZlecenieStatus = _context.ZlecenieStatus.FirstOrDefault(x => x.Id == request.ZlecenieStatusId);
            if (zlecenieToEdit != null && newZlecenieStatus != null)
            {
                zlecenieToEdit.ZlecenieStatus = newZlecenieStatus;

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
