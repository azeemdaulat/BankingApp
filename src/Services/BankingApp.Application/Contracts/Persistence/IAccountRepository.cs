using BankingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Contracts.Persistence
{
    public interface IAccountRepository : IAsyncRepository<Account>
    {
        Task<Account> GetAccountDetailsAsync(int userId);
    }
}
