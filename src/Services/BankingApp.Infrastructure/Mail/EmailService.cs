using BankingApp.Application.Contracts.Infrastructure;
using BankingApp.Application.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
       
        public ILogger<EmailService> _logger { get; }

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }
        public Task<string> SendEmailAsync(Email email)
        {
            throw new NotImplementedException();
        }
    }
}
