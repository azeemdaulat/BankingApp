using AutoMapper;
using BankingApp.Application.Contracts.Persistence;
using BankingApp.Application.Dtos;
using BankingApp.Application.Features.Account.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Features.Account.Handlers
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountDto>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

       async Task<AccountDto> IRequestHandler<GetAccountQuery, AccountDto>.Handle(GetAccountQuery request, 
            CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetAccountDetailsAsync(request.UserId);
            return _mapper.Map<AccountDto>(account);
        }
    }
}
