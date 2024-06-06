using APBD8.Models;
using EfCodeFirst.EfConfigurations;
using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirst.Context;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Students { get; set; }
    public DbSet<Medicament> Groups { get; set; }
    public DbSet<Patient> StudentGroups { get; set; }
    public DbSet<Prescription> StudentGroups { get; set; }
    public DbSet<Prescription_Medicament> StudentGroups { get; set; }


    public AppDbContext() {}

    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
        modelBuilder.Entity<Student>(s =>
        {
            s.Property()
        });
        */

        /*
        modelBuilder.ApplyConfigurationsFromAssembly();
        */
        
    }
}