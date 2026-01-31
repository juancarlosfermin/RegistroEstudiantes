using System.ComponentModel.DataAnnotations;

public class TiposPuntosEntity
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "La descripción es obligatoria")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El valor de puntos es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser mayor a 0")]
    public int? ValorPuntos { get; set; }

    [Required(ErrorMessage = "El color es obligatorio")]
    public string Color { get; set; } = string.Empty;

    [Required(ErrorMessage = "El icono es obligatorio")]
    public string Icono { get; set; } = string.Empty;

    public bool Activo { get; set; } = true;
}