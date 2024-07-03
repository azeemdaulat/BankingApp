using BankingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Contracts.Persistence
{
    public interface ITransactionRepository : IAsyncRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync(int accountId, int page, int pageSize);
        Task TransferMoneyAsync(int fromAccountId, int toAccountId, decimal amount);
        
    }
}
