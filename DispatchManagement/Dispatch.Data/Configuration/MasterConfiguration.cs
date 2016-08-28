using Dispatch.Model;
using System.Data.Entity.ModelConfiguration;

namespace Dispatch.Data
{

    public class MasterConfiguration : EntityTypeConfiguration<Master>
    {

        public MasterConfiguration()
        {
            HasKey(m=>m.MasterId);

            Property(m => m.Name)
                .IsRequired().HasMaxLength(50);

            Property(m => m.ShortName)
               .HasMaxLength(50);

            Property(m => m.MasterType)
               .IsRequired();

            Property(m => m.Status)
              .IsRequired();

            Property(m => m.UserId)
             .IsRequired();

            Property(m => m.dtCreated)
              .IsRequired();

            Property(m => m.dtModified)
              .IsRequired();

            HasRequired(t => t.MasterTypes).WithRequiredDependent(u => u.Master);
            ToTable("Master");
            
            
        }
       
    }
}
