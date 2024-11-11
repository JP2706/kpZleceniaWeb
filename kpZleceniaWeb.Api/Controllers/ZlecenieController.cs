using kpZleceniaWeb.Shared.Zlecenie.Command;
using kpZleceniaWeb.Shared.Zlecenie.Query;
using kpZleceniaWeb.Shared.Zlecenie.Status.Command;
using kpZleceniaWeb.Shared.Zlecenie.Status.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kpZleceniaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ZlecenieController : BaseApiController
    {
        [HttpGet("get_zlecenie_status")]
        public async Task<IActionResult> GetZlecenieStatus(int id)
        {
            var result = await Mediator.Send(new GetZlecenieStatusQuery { Id = id });

            return Ok(result);
        }

        [HttpPost("add_edit_zlecenie_status")]
        public async Task<IActionResult> AddEditZlecenieStatus(AddEditZlecenieStatusCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost("delete_zlecenie_status")]
        public async Task<IActionResult> DeleteZlecenieStatus(DeleteZlecenieStatusCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost("add_edit_zlecenie")]
        public async Task<IActionResult> AddEditZlecenie(AddEditZlecenieCommand command)
        {
           var result =  await Mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("get_zlecenie")]
        public async Task<IActionResult> GetZlecenie(int id)
        {
            var result = await Mediator.Send(new GetZlecenieQuery { Id = id});

            return Ok(result);
        }

        [HttpPost("change_zlecenie_status")]
        public async Task<IActionResult> ChangeZlecenieStatus(ChangeZlecenieStatusCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost("delete_zlecenie")]
        public async Task<IActionResult> DeleteZlecenie(DeleteZlecenieCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet("get_klient_last_zlecenia")]
        public async Task<IActionResult> GetKlientLastZlecenia(int klientId, int ileZlec)
        {
            var result = await Mediator.Send(new GetKlientLastZleceniaQuery { KlientId = klientId, IleZlec = ileZlec });

            return Ok(result);
        }

        [HttpGet("get_czy_klient_ma_zlecenia")]
        public async Task<IActionResult> GetCzyKlientMaZlecenia(int klientId)
        {
            var result = await Mediator.Send(new GetCzyKlientMaZleceniaQuery { KlientId = klientId});

            return Ok(result);
        }


    }
}
