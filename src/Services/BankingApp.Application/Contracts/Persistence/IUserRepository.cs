using BankingApp.Application.Dtos;
using BankingApp.Application.Response;
using BankingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByRefreshTokenAsync(string token);
        Task AddAsync(User user);
        Task UpdateAsync(User user);


    }
}
