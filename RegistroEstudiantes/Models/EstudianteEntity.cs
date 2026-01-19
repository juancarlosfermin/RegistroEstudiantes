namespace RegistroEstudiantes.Models;

using System.ComponentModel.DataAnnotations;

public class EstudianteEntity
{
    [Key]
    public int EstudianteId { get; set; }

    [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "El Email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del Email no es válido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La Edad es obligatoria.")]
    [Range(1, 120, ErrorMessage = "La edad debe ser válida.")]
    public int Edad { get; set; }
}