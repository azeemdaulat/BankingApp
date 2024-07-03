using BankingApp.Application.Features.Account.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BankingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost(Name="CreateAccount")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async  Task<ActionResult<int>> CreateAccount([FromBody] CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }
        [HttpPut(Name = "UpdateAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateAccountCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var command = new DeleteAccountCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
