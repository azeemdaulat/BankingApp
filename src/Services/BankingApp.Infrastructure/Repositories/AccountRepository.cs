using BankingApp.Application.Contracts.Persistence;
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
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        private readonly BankingAppContext _context;
        public AccountRepository(BankingAppContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<Account> GetAccountDetailsAsync(int userId)
        {
            var account  = await _context.Accounts.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if(account == null)
            {
                throw new ApplicationException("Account is not found");
            }
            return account;
        }
    }
}
