using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiWheeler.Domain;

namespace MultiWheeler.Configurations.Entity
{
    public class BatterySeed : IEntityTypeConfiguration<Battery>
    {
        public void Configure(EntityTypeBuilder<Battery> builder)
        {
            builder.HasData(
                new Battery
                {
                    SN = "4CP27SSGP8960433096",
                    CustomerId = 1,
                }
            );

        }
    }
}
