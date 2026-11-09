using proyectoAPICatalogoW.Data;
using proyectoAPICatalogoW.Dtos;
using proyectoAPICatalogoW.Models;
using Microsoft.EntityFrameworkCore;

namespace proyectoAPICatalogoW.Services;

public class JugadorService : IJugadorService
{
    private readonly AppDbContext _db;

    public JugadorService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<JugadorDto?> CrearAsync(JugadorCrearDto dto)
    {


        var jugador = new Jugador { 
            Nombre = dto.Nombre, Puntaje = 0 
        };
        
        _db.Jugadores.Add(jugador);

        await _db.SaveChangesAsync();



        var cartasAleatorias = await _db.Cartas
            .Where(c => c.JugadorId == null)
            .OrderBy(r => Guid.NewGuid())  ///generacion numeros aleatorios, los asigna y ordena 
            .Take(3)
            .ToListAsync();

        foreach (var carta in cartasAleatorias)
        {
            carta.JugadorId = jugador.Id;
        }
        await _db.SaveChangesAsync();

        return await ObtenerPorIdAsync(jugador.Id);
    }

    public async Task<JugadorDto?> ObtenerPorIdAsync(int id)
    {
        var jugador = await _db.Jugadores
            .AsNoTracking()
            .Include(j => j.Cartas)
            .FirstOrDefaultAsync(j => j.Id == id);

        if (jugador == null) return null;

        return new JugadorDto
        {
            Id = jugador.Id,
            Nombre = jugador.Nombre,
            Puntaje = jugador.Puntaje,
            Cartas = jugador.Cartas
        };
    }

}