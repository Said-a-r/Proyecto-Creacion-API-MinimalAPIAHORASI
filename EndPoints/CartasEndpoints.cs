using proyectoAPICatalogoW.Models;
using proyectoAPICatalogoW.Services;

namespace proyectoAPICatalogoW.Endpoints;

public static class CartasEndpoints
{
    public static void MapCartasEndpoints(this WebApplication app)
    {

        app.MapGet("/cartas", (CartaService service) =>
        {
            return Results.Ok(service.ObtenerTodos());
        })
        .WithName("ObtenerCartas")
        .WithTags("Cartas");

        app.MapGet("/cartas/{id:int}", (int id, CartaService service) =>
        {
            var carta = service.ObtenerPorId(id);

            if (carta == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(carta);
        })
        .WithName("ObtenerCartaPorId")
        .WithTags("Cartas");

        
        app.MapPost("/cartas", (CardPersonaje carta, CartaService service) =>
        {
            var nueva = service.Crear(carta);
            return Results.Created($"/cartas/{nueva.Id}", nueva);
        })
        .WithName("CrearCarta")
        .WithTags("Cartas");

        
        app.MapPut("/cartas/{id:int}", (int id, CardPersonaje carta, CartaService service) =>
        {
            var actualizada = service.Actualizar(id, carta);

            if (actualizada == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(actualizada);
        })
        .WithName("ActualizarCarta")
        .WithTags("Cartas");


        






    }
}