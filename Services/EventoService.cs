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
        foreach (int personajeId in evento.Participantes)
        {
            foreach (Personaje p in CatalogoStore.Personajes)
            {
                if (p.Id == personajeId)
                {
                    if (p.Estado == "muerto")
                    {
                        throw new Exception("Si el personaje esta muerto no puede registrarse");
                    }
                }
            }
        }

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
                foreach (int personajeId in evento.Participantes)
                {
                    foreach (Personaje p in CatalogoStore.Personajes)
                    {
                        if (p.Id == personajeId)
                        {
                            if (p.Estado == "muerto")
                            {
                                throw new Exception("Si el personaje esta muerto no puede registrarse");
                            }
                        }
                    }
                }

                e.Nombre = evento.Nombre;
                e.Fecha = evento.Fecha;
                e.Ubicacion = evento.Ubicacion;
                e.Descripcion = evento.Descripcion;
                e.Participantes = evento.Participantes;
                e.Resultado = evento.Resultado;

                if (evento.Resultado != null && evento.Resultado.Contains("muerto"))
                {
                    foreach (int personajeId in evento.Participantes)
                    {
                        foreach (Personaje p in CatalogoStore.Personajes)
                        {
                            if (p.Id == personajeId)
                            {
                                p.Estado = "muerto";
                            }
                        }
                    }
                }

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

    public object? SimularBatalla(int eventoId)
    {
        Evento? evento = ObtenerPorId(eventoId);

        if (evento == null)
        {
            return null;
        }

        if (evento.Participantes.Count < 2)
        {
            return null;
        }

        int fuerzaBandoA = 0;
        int fuerzaBandoB = 0;
        int participantesConCarta = 0;

        for (int i = 0; i < evento.Participantes.Count; i++)
        {
            int personajeId = evento.Participantes[i];

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

            if (poder > 0)
            {
                if (i % 2 == 0)
                {
                    fuerzaBandoA = fuerzaBandoA + poder;
                }
                else
                {
                    fuerzaBandoB = fuerzaBandoB + poder;
                }

                participantesConCarta = participantesConCarta + 1;
            }
        }

        if (participantesConCarta < 2)
        {
            return null;
        }

        Random random = new Random();
        int factorAleatorio = random.Next(1, 101);

        int fuerzaTotal = fuerzaBandoA + fuerzaBandoB;

        string ganador;
        string criterio;

        if (fuerzaBandoA > fuerzaBandoB)
        {
            ganador = "Bando A";
            criterio = "Mayor fuerza base";
        }
        else if (fuerzaBandoB > fuerzaBandoA)
        {
            ganador = "Bando B";
            criterio = "Mayor fuerza base";
        }
        else
        {
            if (factorAleatorio > 50)
            {
                ganador = "Bando A";
                criterio = "Empate resuelto por aletoriedad";
            }
            else
            {
                ganador = "Bando B";
                criterio = "Empate resuelto por aletoriedad;
            }
        }

        var resultado = new
        {
            EventoId = evento.Id,
            EventoNombre = evento.Nombre,
            FuerzaBandoA = fuerzaBandoA,
            FuerzaBandoB = fuerzaBandoB,
            FuerzaTotal = fuerzaTotal,
            ParticipantesConCarta = participantesConCarta,
            FactorAleatorio = factorAleatorio,
            Ganador = ganador,
            Criterio = criterio
        };

        return resultado;
    }
}