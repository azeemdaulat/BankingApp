using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
    }
}
