using Dispatch.Model;
using System.Data.Entity.ModelConfiguration;

namespace Dispatch.Data
{
    public class CustomerAdvConfiguration : EntityTypeConfiguration<CustomerAdv>
    {
        public CustomerAdvConfiguration()
        {
            HasKey(ca => ca.CustomerAdvId);

            Property(ca => ca.CustomerId)
                .IsRequired();

            Property(ca => ca.CurrencyTypeId)
               .IsRequired();

            Property(ca => ca.MasterId)
               .IsRequired();

            Property(ca => ca.CustomerNotes)
                .HasMaxLength(150);

           
            HasRequired(ca => ca.Customer).WithRequiredDependent(c => c.CustomerAdv);
            HasRequired(ca => ca.Currency).WithRequiredDependent(c => c.CustomerAdv);
            HasRequired(ca => ca.Master).WithRequiredDependent(m => m.CustomerAdv);
            ToTable("CustomerAdv");


        }
    }
}
