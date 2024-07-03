using BankingApp.Application.Contracts.Persistence;
using BankingApp.Application.Dtos;
using BankingApp.Application.Response;
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
    public class UserRepository :  RepositoryBase<User>, IUserRepository
    {
        private readonly BankingAppContext _context;
        public UserRepository(BankingAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                                 .Include(u => u.ContactDetails)
                                 .Include(u => u.RefreshTokens)
                                 .FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task<User> GetByRefreshTokenAsync(string token)
        {
            return await _context.Users
                                 .Include(u => u.ContactDetails)
                                 .Include(u => u.RefreshTokens)
                                 .FirstOrDefaultAsync(u => u.RefreshTokens.Any(rt => rt.Token == token));
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

       
    }
}
