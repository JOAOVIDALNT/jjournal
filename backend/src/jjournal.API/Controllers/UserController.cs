using jjournal.Application.UseCases.User.Login;
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

        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterUser([FromServices] IRegisterUserUseCase useCase, [FromBody] RegisterUserRequest request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
        //add unhautorized
        public async Task<IActionResult> Login([FromServices] IUserLoginUseCase useCase, [FromBody] UserLoginRequest request)
        {
            var result = await useCase.Execute(request);

            return Ok(result);
        }
    }
}