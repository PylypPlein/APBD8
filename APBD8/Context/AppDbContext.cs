using APBD8.EfConfigurations;
using APBD8.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirst.Context;

public class AppDbContext : DbContext
{
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Patient> Patients { get; set; }


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
        modelBuilder.ApplyConfiguration(new MedicamentEfConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEfConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorEfConfiguration());
        modelBuilder.ApplyConfiguration(new PrescriptionEfConfiguration());
        modelBuilder.ApplyConfiguration(new PatientEfConfiguration());

        // Seed data
        modelBuilder.Entity<Doctor>().HasData(new Doctor
        {
            IdDoctor = 1,
            FirstName = "Adam",
            LastName = "Kowalski",
            Email = "a.kowalski@example.com"
        });

        modelBuilder.Entity<Patient>().HasData(new Patient
        {
            IdPatient = 1,
            FirstName = "Anna",
            LastName = "Kowalska",
            Birthdate = new DateTime(1990, 1, 1)
        });
    }
}