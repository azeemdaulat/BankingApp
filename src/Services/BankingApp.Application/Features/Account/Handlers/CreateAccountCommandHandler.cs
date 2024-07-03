using AutoMapper;
using BankingApp.Application.Contracts.Persistence;
using BankingApp.Application.Features.Account.Command;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Features.Account.Handlers
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAccountCommandHandler> _logger;

        public CreateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper, ILogger<CreateAccountCommandHandler> logger)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var newAccount = _mapper.Map<Domain.Entities.Account>(request);

            // Save the new account to the database
            await _accountRepository.AddAsync(newAccount);

            _logger.LogInformation($"Account created with ID {newAccount.Id}");

            return newAccount.Id;

        }
    }
}
