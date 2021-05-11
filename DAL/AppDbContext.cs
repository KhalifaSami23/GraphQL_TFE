using Microsoft.EntityFrameworkCore;
using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.User)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<Property> CommandProperty {get; set;}
        public DbSet<User> CommandUser {get; set;}
        public DbSet<Contract> CommandContract {get; set;}
        
    }
}