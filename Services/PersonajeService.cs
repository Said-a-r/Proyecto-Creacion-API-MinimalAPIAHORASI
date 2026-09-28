using proyectoAPICatalogoW.Data;
using proyectoAPICatalogoW.Models;

namespace proyectoAPICatalogoW.Services;

public class PersonajeService
{

    public List<Personaje> ObtenerTodos()
    {
        List<Personaje> resultado = new List<Personaje>();

        foreach (Personaje p in CatalogoStore.Personajes)
        {
            resultado.Add(p);
        }

        return resultado;
    }

    public Personaje? ObtenerPorId(int id)
    {
        foreach (Personaje p in CatalogoStore.Personajes)
        {
            if (p.Id == id)
            {
                return p;
            }
        }

        return null;
    }

    public Personaje Crear(Personaje personaje)
    {
        personaje.Id = CatalogoStore.SiguienteIdPersonaje;
        CatalogoStore.Personajes.Add(personaje);
        return personaje;
    }

    public Personaje? Actualizar(int id, Personaje personaje)
    {
        foreach (Personaje p in CatalogoStore.Personajes)
        {
            if (p.Id == id)
            {
                p.Nombre = personaje.Nombre;
                p.Especie = personaje.Especie;
                p.Faccion = personaje.Faccion;
                p.Afiliacion = personaje.Afiliacion;
                p.Estado = personaje.Estado;
                p.FuerzaSensitivo = personaje.FuerzaSensitivo;

                return p;
            }
        }

        return null;
    }

    public bool Eliminar(int id)
    {
        Personaje? encontrado = null;

        foreach (Personaje p in CatalogoStore.Personajes)
        {
            if (p.Id == id)
            {
                encontrado = p;
                break;
            }
        }

        if (encontrado is null)
        {
            return false;
        }

        CatalogoStore.Personajes.Remove(encontrado);
        return true;
    }

    public List<Personaje> Filtrar(string? faccion, bool? fuerzaSensitivo)
    {
        List<Personaje> resultado = new List<Personaje>();

        foreach (Personaje p in CatalogoStore.Personajes)
        {
            bool cumpleFaccion = true;
            bool cumpleFuerza = true;

            if (!string.IsNullOrWhiteSpace(faccion))
            {
                if (p.Faccion != faccion)
                {
                    cumpleFaccion = false;
                }
            }

            if (fuerzaSensitivo.HasValue)
            {
                if (p.FuerzaSensitivo != fuerzaSensitivo.Value)
                {
                    cumpleFuerza = false;
                }
            }

            if (cumpleFaccion && cumpleFuerza)
            {
                resultado.Add(p);
            }
        }

        return resultado;
    }

    public List<Personaje> RankingPorPoder()
    {
        List<Personaje> personajes = new List<Personaje>();

        foreach (Personaje p in CatalogoStore.Personajes)
        {
            personajes.Add(p);
        }

    
        return personajes
            .OrderByDescending(p =>
            {
                
                CardPersonaje? carta = null;

                foreach (CardPersonaje c in CatalogoStore.Cartas)
                {
                    if (c.PersonajeId == p.Id)
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

                return poder;
            })
            .ToList();
    }
}


