using proyectoAPICatalogoW.Models;
using proyectoAPICatalogoW.Services;

namespace proyectoAPICatalogoW.Endpoints;

public static class PersonajesEndpoints
{
    public static void MapPersonajesEndpoints(this RouteGroupBuilder api)
    {
       
       var group = api.MapGroup("/personajes")
            .WithTags("Personajes");


        group.MapGet("", (PersonajeService service, string? faccion, bool? fuerzaSensitivo) =>
        {
            var personajes = service.Filtrar(faccion, fuerzaSensitivo);
            return Results.Ok(personajes);
        })
        .WithName("ObtenerPersonajes")
        .WithSummary("Obtiene todos los personajes")
        .Produces<List<Personaje>>(200);

        
        group.MapGet("/{id:int}", (int id, PersonajeService service) =>
        {
            var personaje = service.ObtenerPorId(id);

            if (personaje == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(personaje);
        })
        .WithName("ObtenerPersonajePorId")
        .WithSummary("Obtiene un personaje por su ID")
        .Produces<Personaje>(200)
        .Produces(404);

        group.MapPost("", (Personaje personaje, PersonajeService service) =>
        {
            if (string.IsNullOrWhiteSpace(personaje.Nombre))
            {
                return Results.BadRequest("El nombre es obligatorio");
            }

            var nuevo = service.Crear(personaje);
            return Results.Created($"/personajes/{nuevo.Id}", nuevo);
        })
        .WithName("CrearPersonaje")
        .WithSummary("Crea un nuevo personaje")
        .Produces<Personaje>(201)
        .Produces(400);

        group.MapPut("/{id:int}", (int id, Personaje personaje, PersonajeService service) =>
        {
            var actualizado = service.Actualizar(id, personaje);

            if (actualizado == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(actualizado);
        })
        .WithName("ActualizarPersonaje")
        .WithSummary("Actualiza un personaje existente")
        .Produces<Personaje>(200)
        .Produces(404);

        group.MapDelete("/{id:int}", (int id, PersonajeService service) =>
        {
            var eliminado = service.Eliminar(id);

            if (eliminado == false)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        })
        .WithName("EliminarPersonaje")
        .WithSummary("Elimina un personaje por su ID")
        .Produces(204)
        .Produces(404);

        group.MapGet("/{id:int}/eventos", (int id, EventoService eventoService) =>
        {
            var eventos = eventoService.ObtenerEventosDePersonaje(id);
            return Results.Ok(eventos);
            })
            .WithName("ObtenerEventosDePersonaje")
            .WithSummary("Obtiene los eventos de un personaje")
            .Produces<List<Evento>>(200);
            
        group.MapGet("/ranking", (PersonajeService service, string? por) =>
        {
            List<Personaje> ranking;
            if (por == "poder")
            {
                ranking = service.RankingPorPoder();
            }else
            {
                ranking = service.ObtenerTodos();
            }
            return Results.Ok(ranking);
            })
            .WithName("RankingPersonajes")
            .WithSummary("Obtiene el ranking de personajes")
            .Produces<List<Personaje>>(200);


    }
}