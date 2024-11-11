using kpZleceniaWeb.Shared.Firma.Command;
using kpZleceniaWeb.Shared.Firma.Query;
using kpZleceniaWeb.Shared.Zlecenie.Query;
using kpZleceniaWeb.Shared.Zlecenie.Status.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kpZleceniaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FirmaController : BaseApiController
    {
        [HttpPost("add_edit_firma")]
        public async Task<IActionResult> AddEditFirma(AddEditFirmaCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("czy_firma")]
        public async Task<IActionResult> CzyFirma()
        {
           var result =  await Mediator.Send(new CzyBrakFirmyQuery());

            return Ok(result);
        }

        [HttpGet("get_firma")]
        public async Task<IActionResult> GetFirma()
        {
            var result = await Mediator.Send(new GetFirmaQuery());

            return Ok(result);
        }
    }
}
