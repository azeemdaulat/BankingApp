using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Application.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
    }
}
