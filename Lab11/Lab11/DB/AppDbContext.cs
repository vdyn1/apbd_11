namespace Lab11.Data;

using Microsoft.EntityFrameworkCore;
using Lab11.Models;

public class AppDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasKey(pm => new { pm.IdPrescription, pm.IdMedicament });

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdPrescription);

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne(pm => pm.Medicament)
            .WithMany(m => m.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdMedicament);

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                IdDoctor = 1,
                FirstName = "Anna",
                LastName = "Nowak",
                Email = "anna.nowak@example.com"
            }
        );
        
        modelBuilder.Entity<Medicament>().HasData(
            new Medicament
            {
                IdMedicament = 1,
                Name = "Paracetamol",
                Description = "Painkiller",
                Type = "Tablet"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "Ibuprofen",
                Description = "Anti-inflammatory",
                Type = "Capsule"
            }
        );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                IdPrescription = 1,
                Date = new DateTime(2024, 1, 1),
                DueDate = new DateTime(2024, 1, 10),
                IdPatient = 1,
                IdDoctor = 1
            }
        );
        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                IdPatient = 1,
                FirstName = "John",
                LastName = "Smith",
                BirthDate = new DateTime(1980, 1, 1)
            },
            new Patient
            {
                IdPatient = 2,
                FirstName = "Emily",
                LastName = "Johnson",
                BirthDate = new DateTime(1992, 6, 15)
            }
        );

        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament
            {
                IdPrescription = 1,
                IdMedicament = 1,
                Dose = 2,
                Description = "Take after meals"
            },
            new PrescriptionMedicament
            {
                IdPrescription = 1,
                IdMedicament = 2,
                Dose = 1,
                Description = "Before bedtime"
            }
        );
    }
}