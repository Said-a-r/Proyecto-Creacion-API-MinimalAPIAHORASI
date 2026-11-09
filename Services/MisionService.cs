using proyectoAPICatalogoW.Data;
using proyectoAPICatalogoW.Dtos;
using Microsoft.EntityFrameworkCore;

namespace proyectoAPICatalogoW.Services;

public class MisionService : IMisionService
{
    private readonly AppDbContext _db;
    private readonly ICifradoService _cifrado;

    public MisionService(AppDbContext db, ICifradoService cifrado)
    {
        _db = db;
        _cifrado = cifrado;
    }

    public async Task<string> SimularMisionAsync(int misionId, SimularMisionDto dto)
    {
        var jugador = await _db.Jugadores.Include(j => j.Cartas).FirstOrDefaultAsync(j => j.Id == dto.JugadorId);
        var mision = await _db.Misiones.FindAsync(misionId);

        if (jugador == null) throw new Exception("Jugador no encontrado");
        if (mision == null) throw new Exception("Mision no encontrada");

        int poderTotal = jugador.Cartas.Sum(c => c.Poder);

        if (poderTotal >= mision.PoderRequerido)
        {
            int puntajeActual = int.Parse(_cifrado.Descifrar(jugador.PuntajeCifrado));
            int nuevoPuntaje = puntajeActual + mision.PuntosRecompensa;
            
            jugador.PuntajeCifrado = _cifrado.Cifrar(nuevoPuntaje.ToString());

            var nuevaCarta = await _db.Cartas
                .Where(c => c.JugadorId == null)
                .OrderBy(r => Guid.NewGuid())
                .FirstOrDefaultAsync();

            if (nuevaCarta != null)
            {
                nuevaCarta.JugadorId = jugador.Id;
            }
            
            await _db.SaveChangesAsync();
            return $"Misiion superada. Las recompensas son {mision.PuntosRecompensa} puntos y una carta nueva";
        }
        else
        {
            throw new InvalidOperationException($"Mision fallida debido al poder total requerido {mision.PoderRequerido}");
        }
    }
}