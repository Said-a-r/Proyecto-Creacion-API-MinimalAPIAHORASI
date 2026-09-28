using proyectoAPICatalogoW.Models;
using proyectoAPICatalogoW.Services;

namespace proyectoAPICatalogoW.Endpoints;

public static class EventosEndpoints
{
    public static void MapEventosEndpoints(this WebApplication app)
    {

        app.MapGet("/eventos", (EventoService service) =>
        {
            return Results.Ok(service.ObtenerTodos());
        })
        .WithName("ObtenerEventos")
        .WithTags("Eventos");


        app.MapGet("/eventos/{id:int}", (int id, EventoService service) =>
        {
            var evento = service.ObtenerPorId(id);

            if (evento == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(evento);
        })
        .WithName("ObtenerEventoPorId")
        .WithTags("Eventos");


        app.MapPost("/eventos", (Evento evento, EventoService service) =>
        {
            var nuevo = service.Crear(evento);
            return Results.Created($"/eventos/{nuevo.Id}", nuevo);
        })
        .WithName("CrearEvento")
        .WithTags("Eventos");


        app.MapPut("/eventos/{id:int}", (int id, Evento evento, EventoService service) =>
        {
            var actualizado = service.Actualizar(id, evento);

            if (actualizado == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(actualizado);
        })
        .WithName("ActualizarEvento")
        .WithTags("Eventos");
    }
}