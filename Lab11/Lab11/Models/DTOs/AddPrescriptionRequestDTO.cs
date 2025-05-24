namespace Lab11.Models.DTOs;



public class AddPrescriptionRequestDTO
{
    public PatientDTO Patient { get; set; } = null!;
    public List<PrescriptionMedicamentDTO> Medicaments { get; set; } = new();
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdDoctor { get; set; }
}
