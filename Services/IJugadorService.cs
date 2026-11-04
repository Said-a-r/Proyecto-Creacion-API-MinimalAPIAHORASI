using proyectoAPICatalogoW.Dtos;

namespace proyectoAPICatalogoW.Services;

public interface IJugadorService
{
    Task<JugadorDto?> CrearAsync(JugadorCrearDto dto);
    Task<JugadorDto?> ObtenerPorIdAsync(int id);
    Task<string> SimularMisionAsync(int misionId, SimularMisionDto dto);
}
