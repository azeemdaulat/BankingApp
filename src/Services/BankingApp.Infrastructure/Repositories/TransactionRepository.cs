using Azure;
using BankingApp.Application.Common;
using BankingApp.Application.Contracts.Persistence;
using BankingApp.Application.Dtos;
using BankingApp.Domain.Entities;
using BankingApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Repositories
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        private readonly BankingAppContext _context;
        public TransactionRepository(BankingAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(int accountId, int page, int pageSize)
        {
            return await _context.Transactions
            .Where(t => t.AccountId == accountId)
            .OrderBy(t => t.Date)  // Assuming you want to order by date, adjust as necessary
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        }

        public async Task TransferMoneyAsync(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAccount = await _context.Accounts.FindAsync(fromAccountId);
            var toAccount = await _context.Accounts.FindAsync(toAccountId);

            if (fromAccount == null || toAccount == null || fromAccount.Balance < amount)
            {
                throw new InvalidOperationException("Invalid transfer operation");
            }

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            var transaction = new Transaction
            {
                AccountId = fromAccountId,
                Amount = -amount,
                Date = DateTime.UtcNow,
                Description = $"Transfer to account {toAccountId}"
            };

            await _context.Transactions.AddAsync(transaction);

            transaction = new Transaction
            {
                AccountId = toAccountId,
                Amount = amount,
                Date = DateTime.UtcNow,
                Description = $"Transfer from account {fromAccountId}"
            };

            await _context.Transactions.AddAsync(transaction);

            await _context.SaveChangesAsync();
        }
    }
}
