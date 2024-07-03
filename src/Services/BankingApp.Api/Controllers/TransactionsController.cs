using BankingApp.Application.Dtos;
using BankingApp.Application.Features.Transaction.Command;
using BankingApp.Application.Features.Transaction.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("{accountId}/transactions")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetTransactions(int accountId,int page, int pagesize)
        {
            var transactions = await _mediator.Send(new GetTransactionsQuery(accountId,page,pagesize));
            return Ok(transactions);
        }

        [HttpPost("transfer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> TransferMoney([FromBody] TransferMoneyCommand request)
        {
            await _mediator.Send(new TransferMoneyCommand(request.FromAccountId, request.ToAccountId, request.Amount));
            return Ok();
        }
    }
}
