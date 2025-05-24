namespace Lab11.Models.DTOs;



public class PrescriptionMedicamentDTO
{
    public int IdMedicament { get; set; }
    public int Dose { get; set; }
    public string Description { get; set; } = null!;
}
