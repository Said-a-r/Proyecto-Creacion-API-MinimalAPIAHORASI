using proyectoAPICatalogoW.Models;

namespace proyectoAPICatalogoW.Dtos;

public class JugadorCrearDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

}

