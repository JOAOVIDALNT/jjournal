using jjournal.Application.UseCases.User.Register;
using jjournal.Communication.Requests.User;
using jjournal.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace jjournal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RegisterUser([FromServices] IRegisterUserUseCase useCase, [FromBody] RegisterUserRequest request)
        {
            await useCase.Execute(request);

            return NoContent();
        }
    }
}