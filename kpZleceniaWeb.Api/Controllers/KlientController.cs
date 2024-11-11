using kpZleceniaWeb.Shared.Klient.Command;
using kpZleceniaWeb.Shared.Klient.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kpZleceniaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KlientController : BaseApiController
    {
        [HttpGet("get_klient")]
        public async Task<IActionResult> GetKlient(int id)
        {
            var result = await Mediator.Send(new GetKlientQuery { Id = id});

            return Ok(result);
        }

        [HttpPost("add_edit_klient")]
        public async Task<IActionResult> AddEditKlient(AddEditKlientCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost("delete_klient")]
        public async Task<IActionResult> DeleteKlient(DeleteKlientCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
