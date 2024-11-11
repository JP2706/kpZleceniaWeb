using kpZleceniaWeb.Shared.User.Command;
using kpZleceniaWeb.Shared.User.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kpZleceniaWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseApiController
    {
        [HttpGet("get_user")]
        public async Task<IActionResult> GetUser(string id)
        {
            var result = await Mediator.Send(new GetUserQuery { Id = id});

            return Ok(result);
        }

        [HttpPost("add_edit_user")]
        public async Task<IActionResult> AddEditUser([FromBody] AddEditUserCommand command)
        {
           var result =  await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("delete_user")]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

    }
}
