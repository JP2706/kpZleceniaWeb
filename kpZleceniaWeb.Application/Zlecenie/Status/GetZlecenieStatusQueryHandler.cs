using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Shared.Zlecenie.Status.Dto;
using kpZleceniaWeb.Shared.Zlecenie.Status.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace kpZleceniaWeb.Application.Zlecenie.Status
{
    public class GetZlecenieStatusQueryHandler : KpBaseHandler, IRequestHandler<GetZlecenieStatusQuery, List<GetZlecenieStatusDto>>
    {
        public GetZlecenieStatusQueryHandler(IApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<GetZlecenieStatusDto>> Handle(GetZlecenieStatusQuery request, CancellationToken cancellationToken)
        {
            var returnList = new List<GetZlecenieStatusDto>();
            if(request.Id == 0)
            {
                var statusesFromDb = _context.ZlecenieStatus.ToList();
                foreach(var status in statusesFromDb)
                {
                    returnList.Add(new GetZlecenieStatusDto { Id = status.Id, Nazwa = status.Nazwa });
                }
            }
            else
            {
                var status = await _context.ZlecenieStatus.FirstOrDefaultAsync(x => x.Id == request.Id);
                if(status != null)
                {
                    returnList.Add(new GetZlecenieStatusDto { Id = status.Id, Nazwa = status.Nazwa });
                }
            }

            return returnList;
        }
    }
}
