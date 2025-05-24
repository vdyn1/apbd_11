using Lab11.Data;
using Lab11.Models.DTOs;
using Lab11.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Services;

public class PrescriptionService : IPrescriptionService
{
    private readonly AppDbContext _context;

    public PrescriptionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<string> AddPrescriptionAsync(AddPrescriptionRequestDTO request)
    {
        if (request.Medicaments.Count > 10)
            return "Cannot add more than 10 medicaments to a prescription.";

        if (request.DueDate < request.Date)
            return "DueDate cannot be earlier than Date.";

        var doctor = await _context.Doctors
            .FirstOrDefaultAsync(d => d.IdDoctor == request.IdDoctor);

        if (doctor == null)
            return $"Doctor with ID {request.IdDoctor} does not exist.";

        // Проверка: медикаменты существуют
        var medicamentIds = request.Medicaments.Select(m => m.IdMedicament).ToList();
        var foundMedicamentIds = await _context.Medicaments
            .Where(m => medicamentIds.Contains(m.IdMedicament))
            .Select(m => m.IdMedicament)
            .ToListAsync();

        var missing = medicamentIds.Except(foundMedicamentIds).ToList();
        if (missing.Any())
            return $"The following medicament IDs were not found: {string.Join(", ", missing)}";

        // Проверка: есть ли пациент
        var patient = await _context.Patients.FindAsync(request.Patient.IdPatient);
        if (patient == null)
        {
            patient = new Patient
            {
                IdPatient = request.Patient.IdPatient,
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                BirthDate = request.Patient.BirthDate
            };
            _context.Patients.Add(patient);
        }

        // Создание рецепта
        var prescription = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            Patient = patient,
            Doctor = doctor,
            PrescriptionMedicaments = request.Medicaments.Select(m => new PrescriptionMedicament
            {
                IdMedicament = m.IdMedicament,
                Dose = m.Dose,
                Description = m.Description
            }).ToList()
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        return "Prescription added successfully.";
    }
    
   
}
