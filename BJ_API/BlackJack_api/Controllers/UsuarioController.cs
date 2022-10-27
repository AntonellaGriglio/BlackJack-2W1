namespace BlackJack_api.Controllers;

using BlackJack_api.Comandos.Usuarios;
using BlackJack_api.Models;
using BlackJack_api.Resultados.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UsuarioController : ControllerBase
{
    private readonly blackjackContext _context;

    public UsuarioController(blackjackContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("api/user/login")]
    public async Task<ActionResult<RdoLogin>> login([FromBody] Cmdusuario cmd)
    {
        try
        {
            var rdo = new RdoLogin();
            var usuario = await _context.Usuarios.Where(c => c.Usuario1.Equals(cmd.Usuario) &&
             c.Password.Equals(cmd.Password)).FirstOrDefaultAsync();

            if (User != null)
            {
                rdo.usuario = usuario.Usuario1;
                rdo.StatusCode = 200;
                rdo.id = usuario.IdUsuario;
                return Ok(rdo);
            }
            else
            {
                rdo.setError("Usuario no encontrado");
                rdo.StatusCode = 400;
                return Ok(rdo);
            }
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

    [HttpPost]
    [Route("api/user/crear")]
    public async Task<ActionResult<RdoUsuario>> crearUsuario([FromBody] Cmdusuario cmd)
    {
        try
        {
            var rdo = new RdoUsuario();

            var jugador = new Usuario()
            {
                Usuario1 = cmd.Usuario,
                Password = cmd.Password
            };
            await _context.AddAsync(jugador);
            await _context.SaveChangesAsync();

            rdo.id = jugador.IdUsuario;
            rdo.nombreUsuario = jugador.Usuario1;

            return rdo;
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

    [HttpGet]
    [Route("api/user/getById/{id}")]
    public async Task<ActionResult<RdoUsuario>> getUbyId(int id)
    {
        try
        {
            var result = new RdoUsuario();
            var usuario = await _context.Usuarios.Where(c => c.IdUsuario.Equals(id)).FirstOrDefaultAsync();

            if (usuario != null)
            {
                result.id = usuario.IdUsuario;
                result.nombreUsuario = usuario.Usuario1;
            }
            return result;
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }
}