using BankingApp.Domain.Common;

namespace BankingApp.Domain.Entities
{
    public class ContactDetails : EntityBase

    {      
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
