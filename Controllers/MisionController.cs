using proyectoAPICatalogoW.Dtos;
using proyectoAPICatalogoW.Services;
using Microsoft.AspNetCore.Mvc;

namespace proyectoAPICatalogoW.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MisionesController : ControllerBase
{
    private readonly IMisionService _service;

    public MisionesController(IMisionService service)
    {
        _service = service;
    }

    [HttpPost("{id:int}/simular")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Simular(int id, SimularMisionDto dto)
    {
        try
        {
            var resultado = await _service.SimularMisionAsync(id, dto);
            return Ok(new { mensaje = resultado });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { error = ex.Message }); 
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message }); 
        }
    }
}