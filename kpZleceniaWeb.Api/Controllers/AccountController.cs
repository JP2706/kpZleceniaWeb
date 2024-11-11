using kpZleceniaWeb.Shared.Authentication.Commands;
using kpZleceniaWeb.Shared.Authentication.Dtos;
using kpZleceniaWeb.Shared.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace kpZleceniaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(
            [FromBody] RegisterUserCommand command)
        {
            if (command == null || !ModelState.IsValid)
                return BadRequest();

            await Mediator.Send(command);

            return Ok(new ResponseDto { IsSuccess = true });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginUserCommand command)
        {
            var result = await Mediator.Send(command);

            if (!result.IsAuthSuccessful)
            {
                return Unauthorized(new LoginUserDto
                {
                    ErrorMessage = result.ErrorMessage
                });
            }

            return Ok(result);
        }
    }
}
