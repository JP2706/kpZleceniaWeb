using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using kpZleceniaWeb.Shared.Klient.Command;
using MediatR;

namespace kpZleceniaWeb.Application.Klient
{
    public class AddEditKlientCommandHandler : KpBaseHandler, IRequestHandler<AddEditKlientCommand>
    {
        public AddEditKlientCommandHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task Handle(AddEditKlientCommand request, CancellationToken cancellationToken)
        {
            if(request.Id == 0)
            {
                var klient = new Domain.Entities.Klient
                {
                    Imie = request.Imie,
                    Nazwa = request.Nazwa,
                    Nazwisko = request.Nazwisko,
                    Tel = request.Tel,
                };

                _context.Klient.Add(klient);
            }
            else
            {
                var klient = _context.Klient.FirstOrDefault(x => x.Id == request.Id);
                if(klient != null)
                {
                    klient.Imie = request.Imie;
                    klient.Nazwisko = request.Nazwisko;
                    klient.Tel = request.Tel;
                    klient.Nazwa = request.Nazwa;

                    _context.Klient.Update(klient);
                }
            }

           await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
