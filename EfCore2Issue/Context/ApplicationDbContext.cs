using EfCore2Issue.Model;
using Microsoft.EntityFrameworkCore;

namespace EfCore2Issue.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DateHolder> Holders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpecificDate>()
                .HasKey(d => new { d.Date, d.SpecificScheduleId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Foofy1;Trusted_Connection=True;");
        }
    }
}
