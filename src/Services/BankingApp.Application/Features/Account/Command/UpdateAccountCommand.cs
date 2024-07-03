using MediatR;

namespace BankingApp.Application.Features.Account.Command
{
    public class UpdateAccountCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
    }
}
