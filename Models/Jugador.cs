using System.Collections.Generic;
namespace proyectoAPICatalogoW.Models;

public class Jugador
{
    public int Id { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string PuntajeCifrado { get; set; } = string.Empty;
    public List<CardPersonaje> Cartas { get; set; } = new();
}