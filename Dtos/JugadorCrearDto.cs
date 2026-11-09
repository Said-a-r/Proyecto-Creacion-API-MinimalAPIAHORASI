using System.ComponentModel.DataAnnotations; 
using proyectoAPICatalogoW.Models;

namespace proyectoAPICatalogoW.Dtos;

public class JugadorCrearDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contrasenia es obligatoria")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "La contrasenia debe tener entre 8 y 100 caracteres")]
    public string Password { get; set; } = string.Empty;

}

