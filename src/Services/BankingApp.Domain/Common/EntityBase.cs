using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Domain.Common
{
    public class EntityBase
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set;}
        public DateTime LastUpdatedDate { get; set;}
    }
}
