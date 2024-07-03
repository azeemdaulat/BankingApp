using BankingApp.Application.Models;

namespace BankingApp.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
       Task<string> SendEmailAsync(Email email);
    }
}
