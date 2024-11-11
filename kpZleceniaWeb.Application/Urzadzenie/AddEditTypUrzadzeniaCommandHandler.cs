using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Command;
using MediatR;

namespace kpZleceniaWeb.Application.Urzadzenie
{
    public class AddEditTypUrzadzeniaCommandHandler : KpBaseHandler, IRequestHandler<AddEditTypUrzadzeniaCommand>
    {
        public AddEditTypUrzadzeniaCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task Handle(AddEditTypUrzadzeniaCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == 0)
            {
                var typUrz = new TypUrzadzenia();

                typUrz.Nazwa = request.Nazwa;

                _context.TypUrzadzenia.Add(typUrz);
            }
            else
            {
                var updateTypUrz = _context.TypUrzadzenia.FirstOrDefault(x => x.Id == request.Id);
                if(updateTypUrz != null)
                {
                    updateTypUrz.Nazwa = request.Nazwa;

                    _context.TypUrzadzenia.Update(updateTypUrz);
                }
                
            }

            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
