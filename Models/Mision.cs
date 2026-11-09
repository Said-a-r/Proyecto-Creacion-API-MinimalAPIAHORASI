namespace proyectoAPICatalogoW.Models;

public class Mision
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int PoderRequerido { get; set; }
    public int PuntosRecompensa { get; set; }
}
