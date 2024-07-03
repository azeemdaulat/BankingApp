using BankingApp.Domain.Common;

namespace BankingApp.Domain.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
