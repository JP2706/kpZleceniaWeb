using kpZleceniaWeb.Shared.Authentication.Commands;
using kpZleceniaWeb.Shared.Authentication.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace kpZleceniaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : BaseApiController
    {
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(
            [FromBody] RefreshTokenCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(new LoginUserDto
                {
                    ErrorMessage = "Nieprawidłowe dane."
                });

            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
