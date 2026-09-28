using proyectoAPICatalogoW.Data;
using proyectoAPICatalogoW.Models;

namespace proyectoAPICatalogoW.Services;

public class EventoService
{
    public List<Evento> ObtenerTodos()
    {
        List<Evento> resultado = new List<Evento>();

        foreach (Evento e in CatalogoStore.Eventos)
        {
            resultado.Add(e);
        }

        return resultado;
    }

    public Evento? ObtenerPorId(int id)
    {
        foreach (Evento e in CatalogoStore.Eventos)
        {
            if (e.Id == id)
            {
                return e;
            }
        }

        return null;
    }

    public Evento Crear(Evento evento)
    {
        evento.Id = CatalogoStore.SiguienteIdEvento;
        CatalogoStore.Eventos.Add(evento);
        return evento;
    }

    public Evento? Actualizar(int id, Evento evento)
    {
        foreach (Evento e in CatalogoStore.Eventos)
        {
            if (e.Id == id)
            {
                e.Nombre = evento.Nombre;
                e.Fecha = evento.Fecha;
                e.Ubicacion = evento.Ubicacion;
                e.Descripcion = evento.Descripcion;
                e.Participantes = evento.Participantes;
                e.Resultado = evento.Resultado;

                return e;
            }
        }

        return null;
    }

    public List<Evento> ObtenerEventosDePersonaje(int personajeId)
    {
        List<Evento> resultado = new List<Evento>();

        foreach (Evento e in CatalogoStore.Eventos)
        {
            foreach (int id in e.Participantes)
            {
                if (id == personajeId)
                {
                    resultado.Add(e);
                    break;
                }
            }
        }

        return resultado;
    }

    public Personaje? ObtenerMvp(int eventoId)
    {
        Evento? evento = ObtenerPorId(eventoId);

        if (evento == null)
        {
            return null;
        }

        Personaje? mvp = null;
        int poderMaximo = -1;

        foreach (int personajeId in evento.Participantes)
        {
            Personaje? personaje = null;

            foreach (Personaje p in CatalogoStore.Personajes)
            {
                if (p.Id == personajeId)
                {
                    personaje = p;
                    break;
                }
            }

            if (personaje == null)
            {
                continue;
            }

            CardPersonaje? carta = null;

            foreach (CardPersonaje c in CatalogoStore.Cartas)
            {
                if (c.PersonajeId == personaje.Id)
                {
                    carta = c;
                    break;
                }
            }

            int poder = 0;

            if (carta != null)
            {
                poder = carta.Poder;
            }


            if (poder > poderMaximo)
            {
                poderMaximo = poder;
                mvp = personaje;
            }
        }


        return mvp;
    }
}