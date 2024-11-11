using kpZleceniaWeb.Application.Common.Exceptions;
using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Command;
using MediatR;

namespace kpZleceniaWeb.Application.Urzadzenie
{
    public class DeleteTypUrzadzeniaCommandHandler : KpBaseHandler, IRequestHandler<DeleteTypUrzadzeniaCommand>
    {
        public DeleteTypUrzadzeniaCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task Handle(DeleteTypUrzadzeniaCommand request, CancellationToken cancellationToken)
        {
            var deleteTypUrz = _context.TypUrzadzenia.FirstOrDefault(x => x.Id == request.Id);

            if (deleteTypUrz != null)
            {
                _context.TypUrzadzenia.Remove(deleteTypUrz);

                await _context.SaveChangesAsync();
            }
           
        }
    }
}
