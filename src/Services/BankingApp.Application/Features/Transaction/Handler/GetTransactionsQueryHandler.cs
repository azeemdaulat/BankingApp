using AutoMapper;
using BankingApp.Application.Common;
using BankingApp.Application.Contracts.Persistence;
using BankingApp.Application.Dtos;
using BankingApp.Application.Features.Transaction.Queries;
using MediatR;

namespace BankingApp.Application.Features.Transaction.Handler
{
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, PaginatedList<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PaginatedList<TransactionDto>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            return (PaginatedList<TransactionDto>)await _transactionRepository.GetTransactionsAsync(request.AccountId, request.Page, request.PageSize);
            
        }
    }
}
