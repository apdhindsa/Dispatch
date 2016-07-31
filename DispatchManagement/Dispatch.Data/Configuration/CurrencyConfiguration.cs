using Dispatch.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatch.Data
{
    public class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            HasKey(c => c.CurrencyTypeId);

            Property(c => c.CurrencyName)
                .IsRequired().HasMaxLength(50);

            Property(c => c.CurrencyShortName)
               .IsRequired().HasMaxLength(50);

            Property(c => c.CurrencySymbol)
            .IsRequired().HasMaxLength(50);

            Property(c => c.Status)
              .IsRequired();

            Property(c => c.UserId)
             .IsRequired();

            Property(c => c.dtCreated)
              .IsRequired();

            Property(c => c.dtModified)
              .IsRequired();

            ToTable("Currency");

        }
    }
}
