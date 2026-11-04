namespace BackofficeApi.Models;

public class Jugador
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Puntaje { get; set; } = 0;
    public List<CardPersonaje> Cartas { get; set; } = new();
    
}