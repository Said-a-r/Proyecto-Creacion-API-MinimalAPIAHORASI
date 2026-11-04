using proyectoAPICatalogoW.Models;

namespace proyectoAPICatalogoW.Dtos;

public class JugadorDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Puntaje { get; set; }
    public List<CardPersonaje> Cartas { get; set; } = new();
}

