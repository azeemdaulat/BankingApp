using BankingApp.Application.Dtos;
using MediatR;


namespace BankingApp.Application.Features.Account.Queries
{
    public class GetAccountQuery : IRequest<AccountDto>
    {
        public int UserId { get; set; }

        public GetAccountQuery(int userId)
        {
            UserId = userId;
        }
    }
}
