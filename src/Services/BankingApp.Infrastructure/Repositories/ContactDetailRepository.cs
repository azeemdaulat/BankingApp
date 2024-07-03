using BankingApp.Application.Contracts.Persistence;
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
    public class ContactDetailRepository : RepositoryBase<ContactDetails> , IContactDetailsRepository
    {
        private readonly BankingAppContext _context;
        public ContactDetailRepository(BankingAppContext context) : base(context)
        {
            _context = context;
        }
    }
}
