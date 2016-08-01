using Dispatch.Model;
using System.Data.Entity.ModelConfiguration;

namespace Dispatch.Data
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey(c => c.CustomerId);

            Property(c => c.Name)
                .IsRequired().HasMaxLength(50);

            Property(c => c.Address)
               .IsRequired().HasMaxLength(100);

            Property(c => c.Address2)
               .IsRequired().HasMaxLength(100);

            Property(c => c.Address3)
               .IsRequired().HasMaxLength(100);

            Property(c => c.Country)
               .IsRequired();

            Property(c => c.State)
               .IsRequired();

            Property(c => c.City)
                .HasMaxLength(50)
               .IsRequired();

            Property(c => c.ZipCode)
                .HasMaxLength(50)
               .IsRequired();

            Property(c => c.IsSameAsMailingAddress)
              .IsRequired();

            Property(m => m.PrimaryContact)
                .HasMaxLength(50)
               .IsRequired();

            Property(m => m.Telephone)
                .HasMaxLength(50)
               .IsRequired();

            Property(m => m.Email)
                .HasMaxLength(50)
               .IsRequired();

            Property(m => m.SecondaryContact)
                .HasMaxLength(50)
               .IsRequired();

            Property(m => m.UserId)
             .IsRequired();

            Property(m => m.dtCreated)
              .IsRequired();

            Property(m => m.dtModified)
              .IsRequired();

            
            ToTable("Customer");


        }
    }
}
