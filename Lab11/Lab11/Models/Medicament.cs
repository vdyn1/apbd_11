using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab11.Models;

[Table("Medicament")]
public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(200)]
    public string Description { get; set; } = null!;

    [MaxLength(100)]
    public string Type { get; set; } = null!;

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
}