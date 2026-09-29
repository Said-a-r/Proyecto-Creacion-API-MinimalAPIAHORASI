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
            try
            {
                var nuevo = service.Crear(evento);
                return Results.Created($"/eventos/{nuevo.Id}", nuevo);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        })
        .WithName("CrearEvento")
        .WithTags("Eventos");


        app.MapPut("/eventos/{id:int}", (int id, Evento evento, EventoService service) =>
        {
            try
            {
                var actualizado = service.Actualizar(id, evento);

                if (actualizado == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(actualizado);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        })
        .WithName("ActualizarEvento")
        .WithTags("Eventos");
        
        app.MapGet("/eventos/{id:int}/mvp", (int id, EventoService service) =>
        {
            var mvp = service.ObtenerMvp(id);

            if (mvp == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(mvp);
        })
        .WithName("ObtenerMvpEvento")
        .WithTags("Eventos");

        app.MapPost("/eventos/{id:int}/simular", (int id, EventoService service) =>
        {
            var resultado = service.SimularBatalla(id);

            if (resultado == null)
            {
                return Results.BadRequest("La batalla no se puede simular, se necesita que el eventoe exista o los participantes tengan cartas");
            }

            return Results.Ok(resultado);
        })
        .WithName("SimularBatalla")
        .WithTags("Eventos");
    }
}