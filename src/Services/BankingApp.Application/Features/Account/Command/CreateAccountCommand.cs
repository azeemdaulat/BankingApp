using MediatR;

namespace BankingApp.Application.Features.Account.Command
{
    public class CreateAccountCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
    }
}
