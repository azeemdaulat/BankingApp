using BankingApp.Application.Common;
using BankingApp.Application.Dtos;
using MediatR;


namespace BankingApp.Application.Features.Transaction.Queries
{
    public record GetTransactionsQuery(int AccountId, int Page, int PageSize) : IRequest<PaginatedList<TransactionDto>>;
}
