using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace kpZleceniaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private ISender _mediator;
        public ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
