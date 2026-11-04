using proyectoAPICatalogoW.Dtos;

namespace proyectoAPICatalogoW.Services;

public interface IMisionService
{
    Task<string> SimularMisionAsync(int misionId, SimularMisionDto dto);
}
