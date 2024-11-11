using kpZleceniaWeb.Application.Common.Exceptions;
using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using kpZleceniaWeb.Shared.Zlecenie.Status.Command;
using MediatR;

namespace kpZleceniaWeb.Application.Zlecenie.Status
{
    public class AddEditZlecenieStatusCommandHandler : KpBaseHandler, IRequestHandler<AddEditZlecenieStatusCommand>
    {
        public AddEditZlecenieStatusCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task Handle(AddEditZlecenieStatusCommand request, CancellationToken cancellationToken)
        {
            if(request.Id == 0)
            {
                var statusToBaza = new ZlecenieStatus { Id = request.Id, Nazwa = request.Nazwa };
                _context.ZlecenieStatus.Add(statusToBaza);
            }
            else
            {
                var statusUpdate = _context.ZlecenieStatus.FirstOrDefault(x => x.Id == request.Id);

                if (statusUpdate != null)
                {
                    statusUpdate.Nazwa = request.Nazwa;

                    _context.ZlecenieStatus.Update(statusUpdate);
                }

                
            }

            await _context.SaveChangesAsync();
        }
    }
}
