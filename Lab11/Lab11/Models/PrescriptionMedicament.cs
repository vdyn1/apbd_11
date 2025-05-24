using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab11.Models;

[Table("Prescription_Medicament")]
public class PrescriptionMedicament
{
    [Key, Column(Order = 0)]
    public int IdPrescription { get; set; }

    [Key, Column(Order = 1)]
    public int IdMedicament { get; set; }

    public int Dose { get; set; }

    [MaxLength(100)]
    public string Description { get; set; } = null!;

    [ForeignKey("IdPrescription")]
    public Prescription Prescription { get; set; } = null!;

    [ForeignKey("IdMedicament")]
    public Medicament Medicament { get; set; } = null!;
}