using BankingApp.Domain.Common;

namespace BankingApp.Domain.Entities
{
    public class Account : EntityBase
    {        
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; } 
    }
}
