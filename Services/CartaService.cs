using proyectoAPICatalogoW.Data;
using proyectoAPICatalogoW.Models;

namespace proyectoAPICatalogoW.Services;

public class CartaService
{

    public List<CardPersonaje> ObtenerTodos()
    {
        List<CardPersonaje> resultado = new List<CardPersonaje>();

        foreach (CardPersonaje c in CatalogoStore.Cartas)
        {
            resultado.Add(c);
        }

        return resultado;
    }
    public CardPersonaje? ObtenerPorId(int id)
    {
        foreach (CardPersonaje c in CatalogoStore.Cartas)
        {
            if (c.Id == id)
            {
                return c;
            }
        }

        return null;
    }


    public CardPersonaje Crear(CardPersonaje carta)
    {
        carta.Id = CatalogoStore.SiguienteIdCarta;
        CatalogoStore.Cartas.Add(carta);
        return carta;
    }


    public CardPersonaje? Actualizar(int id, CardPersonaje carta)
    {
        foreach (CardPersonaje c in CatalogoStore.Cartas)
        {
            if (c.Id == id)
            {
                c.PersonajeId = carta.PersonajeId;
                c.Poder = carta.Poder;
                c.HabilidadEspecial = carta.HabilidadEspecial;
                c.Arma = carta.Arma;
                c.NivelPeligrosidad = carta.NivelPeligrosidad;
                c.ImagenUrl = carta.ImagenUrl;

                return c;
            }
        }

        return null;
    }


    public CardPersonaje? ObtenerPorPersonajeId(int personajeId)
    {
        foreach (CardPersonaje c in CatalogoStore.Cartas)
        {
            if (c.PersonajeId == personajeId)
            {
                return c;
            }
        }

        return null;
    }
}


