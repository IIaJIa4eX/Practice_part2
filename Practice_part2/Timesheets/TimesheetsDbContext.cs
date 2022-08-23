using Timesheets.Models;
using Microsoft.EntityFrameworkCore;

namespace Timesheets
{
    public class TimesheetsDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder
            optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=vma-postgres;Database=vma;Username=vma;Password=K8YEW7nZHkX2+cvF; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            // modelBuilder.Entity<Employee>().(s => s.GradeName).HasColumnName("gradename");

            // modelBuilder.Entity<Grade>()
            //     .HasMany(c => c.Users)
            //     .WithOne(e => e.Grade)
            //     .HasForeignKey(d => d.Id)
            //     .IsRequired();
            
            // modelBuilder.Entity<Grade>().Property(s => s.Users).HasColumnName("users");
            
            // modelBuilder.Entity<Grade>()
            //     .HasMany(p => p.Users);

            // modelBuilder.Entity<Grade>()
            //     .HasMany<User>(g => g.Users);
            //
            // modelBuilder.Entity<Grade>()
            //     .HasKey(de => new { de.Users });
            
            // modelBuilder.Entity<Grade>()
            //     .HasMany(u => u.Users)
            //     .HasForeignKey(h => h.UserId);

        }
        public TimesheetsDbContext(DbContextOptions<TimesheetsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
