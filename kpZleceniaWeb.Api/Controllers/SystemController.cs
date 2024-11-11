using kpZleceniaWeb.Shared.Common;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Query;
using kpZleceniaWeb.Shared.User.Command;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kpZleceniaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SystemController : BaseApiController
    {
        [HttpGet("p_app_combo")]
        public async Task<IActionResult> pAppCombo(string forms, string combo)
        {
            var result = await Mediator.Send(new pAppComboQuery { Forms = forms, Combo = combo});

            return Ok(result);
        }
    }
}
