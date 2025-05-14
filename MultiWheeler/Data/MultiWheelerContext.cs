using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiWheeler.Configurations.Entity;
using MultiWheeler.Data;
using MultiWheeler.Domain;

namespace MultiWheeler.Data
{
    public class MultiWheelerContext(DbContextOptions<MultiWheelerContext> options) : IdentityDbContext<MultiWheelerUser>(options)
    {
        public DbSet<MultiWheeler.Domain.Battery> Battery { get; set; } = default!;
        public DbSet<MultiWheeler.Domain.Customer> Customer { get; set; } = default!;
        public DbSet<MultiWheeler.Domain.Report> Report { get; set; } = default!;
        public DbSet<MultiWheeler.Domain.BatteryStatus> BatteryStatus { get; set; } = default!;
        public DbSet<MultiWheeler.Domain.CMD> CMD { get; set; } = default!;
        public DbSet<MultiWheeler.Domain.CMDResult> CMDResult { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BatterySeed());
        }
    }
}
