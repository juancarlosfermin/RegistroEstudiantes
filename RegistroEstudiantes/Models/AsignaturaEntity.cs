using System.ComponentModel.DataAnnotations;

public class AsignaturaEntity
{
    [Key]
    public int AsignaturaId { get; set; }

    [Required(ErrorMessage = "El campo Codigo es obligatorio.")]
    [StringLength(20, ErrorMessage = "El Codigo no puede exceder los 20 caracteres.")]
    public string Codigo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    [StringLength(100, ErrorMessage = "El Nombre no puede exceder los 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo Aula es obligatorio.")]
    [StringLength(50, ErrorMessage = "El Aula no puede exceder los 50 caracteres.")]
    public string Aula { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo Creditos es obligatorio.")]
    [Range(1, 10, ErrorMessage = "Los creditos deben ser mayor a 0 y menor a 10.")]
    public int Creditos { get; set; }
}