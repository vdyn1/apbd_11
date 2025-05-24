using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab11.Models;

[Table("Doctor")]
public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; } = null!;

    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    [MaxLength(100)]
    public string Email { get; set; } = null!;

    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}