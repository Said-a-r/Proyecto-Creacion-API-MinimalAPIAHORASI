using System.ComponentModel.DataAnnotations;

namespace proyectoAPICatalogoW.Dtos;

public class SimularMisionDto
{
    [Required(ErrorMessage = "El ID del jugador es obligatorio")]

    public int JugadorId { get; set; }

}