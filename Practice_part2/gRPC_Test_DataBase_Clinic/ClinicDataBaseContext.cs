using Microsoft.EntityFrameworkCore;

namespace gRPC_Test_DataBase_Clinic
{
    //for_review
    public class ClinicDataBaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Consultation> Consultations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Consultation>().HasOne(p => p.Pet).WithMany(c => c.Consultations).HasForeignKey(p => p.PetId).OnDelete(DeleteBehavior.NoAction);
        }
        public ClinicDataBaseContext(DbContextOptions options) : base(options)
        {
             
        }

    }
}