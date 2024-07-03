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
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAccountCommandHandler> _logger;
        public DeleteAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper, ILogger<UpdateAccountCommandHandler> logger)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var accountToDelete = await _accountRepository.GetByIdAsync(request.Id);
            if (accountToDelete == null)
            {
                throw new ApplicationException($"nameof({accountToDelete}), {request.Id}");
            }
            await _accountRepository.DeleteAsync(accountToDelete);
            _logger.LogInformation($"Account {accountToDelete.Id} is successfully deleted.");
        }
    }
}
