using MediatR;

namespace BankingApp.Application.Features.Transaction.Command
{
    public class TransferMoneyCommand : IRequest

    {
        public TransferMoneyCommand(int fromAccountId, int toAccountId, decimal amount)
        {
            FromAccountId = fromAccountId;
            ToAccountId = toAccountId;
            Amount = amount;
        }

        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Amount { get; set; }


    }
}
