using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Command;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kpZleceniaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UrzadzenieController : BaseApiController
    {
        [HttpGet("get_typ_urzadzenia")]
        public async Task<IActionResult> GetTypUrzadzenia(int id)
        {
            var result = await Mediator.Send(new GetTypUrzadzeniaQuery { Id = id });

            return Ok(result);
        }

        [HttpPost("add_edit_typ_urzadzenia")]
        public async Task<IActionResult> AddEditTypUrzadzenia(AddEditTypUrzadzeniaCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost("delete_typ_urzadzenia")]
        public async Task<IActionResult> DeleteTypUrzadzenia(DeleteTypUrzadzeniaCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
