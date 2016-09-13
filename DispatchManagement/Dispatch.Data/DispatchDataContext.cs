using Dispatch.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatch.Data
{
    public class DispatchDataContext : DbContext
    {

        public DispatchDataContext(): base()
        {

        }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<MasterTypes> MasterTypes { get; set; }
        public DbSet<CustomerAdv> CustomerAdv { get; set; }
        public DbSet<Master> Master { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CurrencyConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new MasterTypesConfiguration());
            modelBuilder.Configurations.Add(new CustomerAdvConfiguration());
            modelBuilder.Configurations.Add(new MasterConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        private void ApplyRules()
        {
             foreach (var entry in this.ChangeTracker.Entries()
                        .Where(
                             e => e.Entity is IAuditInfo &&
                            (e.State == EntityState.Added) ||
                            (e.State == EntityState.Modified)))
            {
                IAuditInfo e = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    e.dtCreated = DateTime.Now.ToUniversalTime();
                }

                e.dtModified = DateTime.Now.ToUniversalTime();
            }
        }

        public override int SaveChanges()
        {
            ApplyRules();
            return base.SaveChanges();
        }
    }
}
