namespace proyectoAPICatalogoW.Models;

public class Personaje
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string Faccion { get; set; } = string.Empty;
    public string Afiliacion { get; set; } = string.Empty;
    public string Estado { get; set; } = "vivo";
    public bool FuerzaSensitivo { get; set; }


    
}