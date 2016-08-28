using Dispatch.Model;
using System.Data.Entity.ModelConfiguration;

namespace Dispatch.Data
{
    public class MasterTypesConfiguration : EntityTypeConfiguration<MasterTypes>
    {

        public MasterTypesConfiguration()
        {
            HasKey(mt => mt.MasterTypeId);

            Property(mt => mt.Name)
                .IsRequired().HasMaxLength(20);

            ToTable("MasterTypes");

        }

    }
}
