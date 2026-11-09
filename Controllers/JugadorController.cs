using proyectoAPICatalogoW.Dtos;
using proyectoAPICatalogoW.Services;
using Microsoft.AspNetCore.Mvc;

namespace proyectoAPICatalogoW.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JugadoresController : ControllerBase
{
    private readonly IJugadorService _service;

    public JugadoresController(IJugadorService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<JugadorDto>> Crear(JugadorCrearDto dto)
    {
        var creado = await _service.CrearAsync(dto);
        
        if (creado is null) 
            return BadRequest(new { mensaje = "No se pudo crear el jugador" });
        return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<JugadorDto>> ObtenerPorId(int id)
    {
        var jugador = await _service.ObtenerPorIdAsync(id);
        
        if (jugador is null) 
            return NotFound();
            
        return Ok(jugador);
    }
}

///Hacer cambios en los services y en el dtp para manejar elementos "activos dntor de la base de datos, esto para no eliminarlo"
/// Esto obviamente tambien predecera un enpoint eliminar 
/// Hace otra migracion con dotnet ef migration add SegundaMigracio [por ejemplo]
/// Aniadir migraciones ?????????? 
/// Volver a reempalzar toda la data del proyecto pero con una estructura completa
/// 