using AutoMapper;
using BankingApp.Application.Contracts.Persistence;
using BankingApp.Application.Features.Account.Command;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BankingApp.Application.Features.Account.Handlers
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAccountCommandHandler> _logger;

        public UpdateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper, ILogger<UpdateAccountCommandHandler> logger)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            //Update account
            var accountToUpdate = await _accountRepository.GetByIdAsync(request.Id);
            if (accountToUpdate == null)
            {
                _logger.LogInformation("record not found.");
            }
            _mapper.Map(request,accountToUpdate,typeof(UpdateAccountCommand), typeof(Domain.Entities.Account));

            await _accountRepository.UpdateAsync(accountToUpdate);
            _logger.LogInformation($"Account is updated with {accountToUpdate.Id}");
        }
    }
}
