
using kpZleceniaWeb.Application.Common.Exceptions;
using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Zlecenie.Status.Command;
using MediatR;

namespace kpZleceniaWeb.Application.Zlecenie.Status
{
    public class DeleteZlecenieStatusCommandHandler : KpBaseHandler, IRequestHandler<DeleteZlecenieStatusCommand>
    {
        public DeleteZlecenieStatusCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task Handle(DeleteZlecenieStatusCommand request, CancellationToken cancellationToken)
        {
            var itemToDelete = _context.ZlecenieStatus.FirstOrDefault(x => x.Id == request.Id);
            if (itemToDelete != null)
            {
                _context.ZlecenieStatus.Remove(itemToDelete);

                await _context.SaveChangesAsync();
            }
               
        }
    }
}
