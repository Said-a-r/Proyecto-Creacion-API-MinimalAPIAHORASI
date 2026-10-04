using proyectoAPICatalogoW.Models;
using proyectoAPICatalogoW.Services;

namespace proyectoAPICatalogoW.Endpoints;

public static class CartasEndpoints
{
    public static void MapCartasEndpoints(this RouteGroupBuilder api)
    {


        var group = api.MapGroup("/cartas")
            .WithTags("Cartas");



        group.MapGet("", (CartaService service) =>
        {
            return Results.Ok(service.ObtenerTodos());
        })
        .WithName("ObtenerCartas")
        .WithSummary("Obtiene todas las cartas")
        .Produces<List<CardPersonaje>>(200);

        group.MapGet("/{id:int}", (int id, CartaService service) =>
        {
            var carta = service.ObtenerPorId(id);

            if (carta == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(carta);
        })
        .WithName("ObtenerCartaPorId")
        .WithSummary("Obtiene una carta por su ID")
        .Produces<CardPersonaje>(200)
        .Produces(404);

        
        group.MapPost("", (CardPersonaje carta, CartaService service) =>
        {
            var nueva = service.Crear(carta);
            return Results.Created($"/cartas/{nueva.Id}", nueva);
        })
        .WithName("CrearCarta")
        .WithSummary("Crea una nueva carta")
        .Produces<CardPersonaje>(201)
        .Produces(400);

        
        group.MapPut("{id:int}", (int id, CardPersonaje carta, CartaService service) =>
        {
            var actualizada = service.Actualizar(id, carta);

            if (actualizada == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(actualizada);
        })
        .WithName("ActualizarCarta")
        .WithSummary("Actualiza una carta existente")
        .Produces<CardPersonaje>(200)
        .Produces(404);

        






    }
}