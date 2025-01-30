using System;
using System.ComponentModel.DataAnnotations;

public class Tarea
{
    [Key] 
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es obligatorio")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria")]
    public string Descripcion { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public string Estado { get; set; } = "En proceso";

    public string Responsable { get; set; } = "Sin asignar";


}
