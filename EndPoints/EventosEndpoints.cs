using proyectoAPICatalogoW.Models;
using proyectoAPICatalogoW.Services;

namespace proyectoAPICatalogoW.Endpoints;

public static class EventosEndpoints
{
    public static void MapEventosEndpoints(this RouteGroupBuilder api)
    {
        var group = api.MapGroup("/eventos")
            .WithTags("Eventos");


        group.MapGet("", (EventoService service) =>
        {
            return Results.Ok(service.ObtenerTodos());
        })
        .WithName("ObtenerEventos")
        .WithSummary("Obtiene todos los eventos")
        .Produces<List<Evento>>(200);


        group.MapGet("/{id:int}", (int id, EventoService service) =>
        {
            var evento = service.ObtenerPorId(id);

            if (evento == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(evento);
        })
        .WithName("ObtenerEventoPorId")
        .WithSummary("Obtiene un evento por su ID")
        .Produces<Evento>(200)
        .Produces(404);

        group.MapPost("", (Evento evento, EventoService service) =>
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
        .WithSummary("Crea un nuevo evento")
        .Produces<Evento>(201)
        .Produces(400);


        group.MapPut("/{id:int}", (int id, Evento evento, EventoService service) =>
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
        .WithSummary("Actualiza un evento existente")
        .Produces<Evento>(200)
        .Produces(400)
        .Produces(404);

        group.MapGet("/{id:int}/mvp", (int id, EventoService service) =>
        {
            var mvp = service.ObtenerMvp(id);

            if (mvp == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(mvp);
        })
        .WithName("ObtenerMvpEvento")
        .WithSummary("Obtiene el MVP de un evento")
        .Produces<Personaje>(200)
        .Produces(404);

        group.MapPost("/{id:int}/simular", (int id, EventoService service) =>
        {
            var resultado = service.SimularBatalla(id);

            if (resultado == null)
            {
                return Results.BadRequest("La batalla no se puede simular, se necesita que el eventoe exista o los participantes tengan cartas");
            }

            return Results.Ok(resultado);
        })
        .WithName("SimularBatalla")
        .WithSummary("Simula una batalla entre los participantes de un evento")
        .Produces(200)
        .Produces(400);
    }
}