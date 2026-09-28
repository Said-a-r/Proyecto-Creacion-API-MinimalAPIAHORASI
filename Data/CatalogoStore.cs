using proyectoAPICatalogoW.Models;

namespace proyectoAPICatalogoW.Data;

public class CatalogoStore
{
    public static List<Personaje> Personajes { get; } = new()
    {
        new Personaje { Id = 1, Nombre = "Darth Vader", Especie = "Humano", Faccion = "Imperio", Afiliacion = "Imperio", Estado = "vivo", FuerzaSensitivo = true },
        new Personaje { Id = 2, Nombre = "Luke Skywalker", Especie = "Humano", Faccion = "Rebelde", Afiliacion = "Alianza Rebelde", Estado = "vivo", FuerzaSensitivo = true },
        new Personaje { Id = 3, Nombre = "Han Solo", Especie = "Humano", Faccion = "Rebelde", Afiliacion = "Alianza Rebelde", Estado = "vivo", FuerzaSensitivo = false },
    };

    public static List<CardPersonaje> Cartas { get; } = new()
    {
        new CardPersonaje { Id = 1, PersonajeId = 1, Poder = 9000, HabilidadEspecial = "Estrangulamiento", Arma = "Sable de luz", NivelPeligrosidad = "Alto", ImagenUrl = "" },
        new CardPersonaje { Id = 2, PersonajeId = 2, Poder = 8500, HabilidadEspecial = "Telequinesis", Arma = "Sable de luz", NivelPeligrosidad = "Alto", ImagenUrl = "" },
        new CardPersonaje { Id = 3, PersonajeId = 3, Poder = 5000, HabilidadEspecial = "Puntería", Arma = "Bláster", NivelPeligrosidad = "Medio", ImagenUrl = "" },
    };

    public static List<Evento> Eventos { get; } = new()
    {
        new Evento { Id = 1, Nombre = "Batalla de Yavin", Fecha = 0, Ubicacion = "Yavin 4", Descripcion = "Batalla decisiva", Participantes = new() { 1, 2 }, Resultado = null },
        new Evento { Id = 2, Nombre = "Batalla de Hoth", Fecha = 3, Ubicacion = "Hoth", Descripcion = "Batalla en el hielo", Participantes = new() { 2, 3 }, Resultado = null },
    };

    public static int SiguienteIdPersonaje => Personajes.Count == 0 ? 1 : Personajes.Max(p => p.Id) + 1;
    public static int SiguienteIdCarta => Cartas.Count == 0 ? 1 : Cartas.Max(c => c.Id) + 1;
    public static int SiguienteIdEvento => Eventos.Count == 0 ? 1 : Eventos.Max(e => e.Id) + 1;
}

