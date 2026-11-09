using proyectoAPICatalogoW.Data;
using proyectoAPICatalogoW.Dtos;
using proyectoAPICatalogoW.Models;
using Microsoft.EntityFrameworkCore;

namespace proyectoAPICatalogoW.Services;

public class JugadorService : IJugadorService
{
    private readonly AppDbContext _db;
    private readonly ICifradoService _cifrado;

    public JugadorService(AppDbContext db, ICifradoService cifrado)
    {
        _db = db;
        _cifrado = cifrado;
    }

    public async Task<JugadorDto?> CrearAsync(JugadorCrearDto dto)
    {
        var jugador = new Jugador { 
            Nombre = dto.Nombre,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            PuntajeCifrado = _cifrado.Cifrar("0")
        };
        
        _db.Jugadores.Add(jugador);
        await _db.SaveChangesAsync();

        var cartasAleatorias = await _db.Cartas
            .Where(c => c.JugadorId == null)
            .OrderBy(r => Guid.NewGuid())
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
                .ThenInclude(c => c.personaje)
            .FirstOrDefaultAsync(j => j.Id == id);

        if (jugador == null) return null;

        int puntajeDescifrado = int.Parse(_cifrado.Descifrar(jugador.PuntajeCifrado));

        return new JugadorDto
        {
            Id = jugador.Id,
            Nombre = jugador.Nombre,
            Puntaje = puntajeDescifrado,
            Cartas = jugador.Cartas
        };
    }
}