using BankingApp.Application.Contracts.Infrastructure;
using BankingApp.Application.Contracts.Persistence;
using BankingApp.Application.Features.Transaction.Command;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BankingApp.Application.Features.Transaction.Handler
{
    public class TransferMoneyHandler : IRequestHandler<TransferMoneyCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger<TransferMoneyCommand> _logger;

        public TransferMoneyHandler(ITransactionRepository transactionRepository, 
            IEmailService emailService, ILogger<TransferMoneyCommand> logger)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        async Task IRequestHandler<TransferMoneyCommand>.Handle(TransferMoneyCommand request, CancellationToken cancellationToken)
        {
            await _transactionRepository.TransferMoneyAsync(request.FromAccountId, request.ToAccountId, request.Amount);
            _logger.LogInformation($"Transaction is place with amount {request.Amount} from acount {request.FromAccountId} to {request.ToAccountId}");
          //  _emailService.SendEmailAsync(new Email() { })
        }
    }
}
