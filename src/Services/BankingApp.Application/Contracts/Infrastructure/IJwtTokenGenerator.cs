using BankingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Contracts.Infrastructure
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
        RefreshToken GenerateRefreshToken();
    }
}
