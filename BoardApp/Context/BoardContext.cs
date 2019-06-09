using BoardApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardApp.Context
{
    public class BoardContext : DbContext
    {
        public BoardContext(DbContextOptions<BoardContext> options) : base(options)
        {
        }
        
        public DbSet<RepairCase> RepairCases { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RepairCase>()
                .HasOne(e => e.Worker);

            modelBuilder.Entity<Worker>()
                .HasMany<RepairCase>()
                .WithOne(e => e.Worker)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RepairCase>()
                .HasOne(e => e.Equipment);



            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Owner);
            
            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}