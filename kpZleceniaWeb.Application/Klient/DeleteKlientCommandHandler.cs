using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Klient.Command;
using MediatR;

namespace kpZleceniaWeb.Application.Klient
{
    public class DeleteKlientCommandHandler : KpBaseHandler, IRequestHandler<DeleteKlientCommand>
    {
        public DeleteKlientCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task Handle(DeleteKlientCommand request, CancellationToken cancellationToken)
        {

            var klient = _context.Klient.FirstOrDefault(x => x.Id == request.KlientId);

            if(klient != null)
            {
                _context.Klient.Remove(klient);

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
