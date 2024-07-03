using BankingApp.Domain.Common;

namespace BankingApp.Domain.Entities
{
    public class Transaction : EntityBase
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string TransactionType { get; set; } 
        public string Description { get; set; } 
    }
}
