using BankingApp.Domain.Common;
using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Infrastructure.Persistence
{
    public class BankingAppContext : DbContext
    {
       public BankingAppContext(DbContextOptions<BankingAppContext> options) : base(options) { }
       public DbSet<Account> Accounts { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "swn";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDate = DateTime.Now;
                        entry.Entity.LastUpdatedBy = "swn";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
