using proyectoAPICatalogoW.Models;
using proyectoAPICatalogoW.Services;

namespace proyectoAPICatalogoW.Endpoints;

public static class PersonajesEndpoints
{
    public static void MapPersonajesEndpoints(this WebApplication app)
    {
       
        app.MapGet("/personajes", (PersonajeService service, string? faccion, bool? fuerzaSensitivo) =>
        {
            var personajes = service.Filtrar(faccion, fuerzaSensitivo);
            return Results.Ok(personajes);
        })
        .WithName("ObtenerPersonajes")
        .WithTags("Personajes");

        
        app.MapGet("/personajes/{id:int}", (int id, PersonajeService service) =>
        {
            var personaje = service.ObtenerPorId(id);

            if (personaje == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(personaje);
        })
        .WithName("ObtenerPersonajePorId")
        .WithTags("Personajes");

        app.MapPost("/personajes", (Personaje personaje, PersonajeService service) =>
        {
            if (string.IsNullOrWhiteSpace(personaje.Nombre))
            {
                return Results.BadRequest("El nombre es obligatorio");
            }

            var nuevo = service.Crear(personaje);
            return Results.Created($"/personajes/{nuevo.Id}", nuevo);
        })
        .WithName("CrearPersonaje")
        .WithTags("Personajes");

        app.MapPut("/personajes/{id:int}", (int id, Personaje personaje, PersonajeService service) =>
        {
            var actualizado = service.Actualizar(id, personaje);

            if (actualizado == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(actualizado);
        })
        .WithName("ActualizarPersonaje")
        .WithTags("Personajes");


        app.MapDelete("/personajes/{id:int}", (int id, PersonajeService service) =>
        {
            var eliminado = service.Eliminar(id);

            if (eliminado == false)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        })
        .WithName("EliminarPersonaje")
        .WithTags("Personajes");
    }
}