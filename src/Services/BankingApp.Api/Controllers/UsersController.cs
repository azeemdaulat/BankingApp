using BankingApp.Application.Dtos;
using BankingApp.Application.Features.Users.Command;
using BankingApp.Application.Features.Users.Queries;
using BankingApp.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserDto userDto)
        {
            var response = await _mediator.Send(new AuthenticateUserCommand(userDto.Username, userDto.PasswordHash));
            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var response = await _mediator.Send(new RefreshTokenCommand(request.Token));
            return Ok(response);
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest request)
        {
            var success = await _mediator.Send(new RevokeTokenCommand(request.Token));
            if (!success)
            {
                return BadRequest("Token is invalid or expired");
            }
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserDetails(int userId)
        {
            var user = await _mediator.Send(new GetUserDetailsQuery(userId));
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            var user = await _mediator.Send(new RegisterUserCommand(userDto));
            return Ok(user);
        }
    }

}
