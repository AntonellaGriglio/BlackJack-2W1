namespace BlackJack_api.Controllers;

using BlackJack_api.Comandos.Jugada;
using BlackJack_api.Models;
using BlackJack_api.Resultados.Jugada;
using BlackJack_api.Resultados.Mazo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class JugadaController : ControllerBase
{
    private readonly blackjackContext _context;

    public JugadaController(blackjackContext context)
    {
        _context = context;
    }

  
    //USO-> "ultimas partidas"
    [HttpGet]
    [Route("api/jugada/lista/{idUsu}")]
    public async Task<ActionResult<RdoJugadas>> listaJugadas(int idUsu)
    {
        try
        {
            var result = new RdoJugadas();
            
            var jugadas = await _context.Jugada.Where(j => j.IdUsuario.Equals(idUsu) && j.Estado.Equals(0)).
            Include(c => c.IdUsuarioNavigation).OrderByDescending(j => j.IdJugada).ToListAsync();
            if (jugadas != null)
            {
                foreach (var jug in jugadas)
                {
                    var resultAux = new RdoJuego()
                    {
                        idJugada = jug.IdJugada,
                        usuario = jug.IdUsuarioNavigation.Usuario1
                    };
                    result.listaJugadas.Add(resultAux);
                }
                return Ok(result);
            }
            else
            {
                return Ok(result);
            }
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

    
   
    [HttpPut]
    [Route("api/jugada/finalizar/{idJug}+{idUsu}")]
    public async Task<ActionResult<bool>> finalizarJugada(int idJug, int idUsu)
    {
        try
        {
            var jugada = await _context.Jugada.Where(j => j.IdJugada.Equals(idJug) && j.IdUsuario.Equals(idUsu)).
            OrderBy(j => j.IdJugada).LastOrDefaultAsync();

            if (jugada != null && jugada.Estado.Equals(0))
            {
                jugada.Estado = 1;

                _context.Update(jugada);
                await _context.SaveChangesAsync();
            }
            return Ok(true);
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

    //USO-> "Nueva Jugada"
    [HttpPost]
    [Route("api/jugada/nueva/{idUsu}")]
    public async Task<ActionResult<RdoJuego>> nuevaJugada([FromBody] CmdJugada cmd, int idUsu)
    {
        try
        {
            var usu1 = await _context.Usuarios.Where(u => u.IdUsuario.Equals(idUsu)).FirstOrDefaultAsync();
            var result = new RdoJuego();

            if (usu1 != null)
            {
                var jug = new Jugadum()
                {
                    IdUsuario = usu1.IdUsuario,
                    Estado = 0
                };
                await _context.AddAsync(jug);
                _context.SaveChanges();

                result.idJugada = jug.IdJugada;
                result.usuario = jug.IdUsuarioNavigation.Usuario1;

                return (result);
            }
            else
            {
                return Ok();
            }
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

    //USO-> "próxima ronda"
    [HttpPost]
    [Route("api/partida/nueva/{idUsu}+{idJug}")]
    public async Task<ActionResult<RdoPartida>> nuevaPartida(int idUsu, int idJug)
    {
        try
        {
            var jug = await _context.Jugada.Where(j => j.IdJugada.Equals(idJug) && j.IdUsuario.Equals(idUsu)
            && j.Estado.Equals(0)).OrderBy(j => j.IdJugada).LastOrDefaultAsync();

            var result = new RdoPartida();

            if (jug != null)
            {
                var part = new Partidum()
                {
                    IdJugada = idJug,
                    PuntosCrupier = 0,
                    PuntosJugador = 0,
                    Estado = 0,
                    Resultado = ""
                };
                await _context.AddAsync(part);
                _context.SaveChanges();

                result.idPartida = part.IdPartida;

                return result;
            }
            else
            {
                return result;
            }
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }


    [HttpPut]
    [Route("api/partida/actualizar/{idUsu}+{idPart}+{idJug}")]
    public async Task<ActionResult<bool>> actualizarPartida([FromBody] CmdPartida cmd, int idJug, int idUsu, int idPart)
    {
        try
        {
            var part = await _context.Partida.Where(p => p.IdPartida.Equals(idPart) && p.IdJugada.Equals(idJug)
            && p.IdJugadaNavigation.IdUsuario.Equals(idUsu)).FirstOrDefaultAsync();

            if (part != null && part.Estado.Equals(0))
            {
                part.IdJugada = idJug;
                part.PuntosCrupier = cmd.puntosCrup;
                part.PuntosJugador = cmd.puntosJug;
                part.Estado = cmd.estado;
                part.Resultado = cmd.resultado;
                

                _context.Update(part);
                await _context.SaveChangesAsync();
            }
            return Ok(true);
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

    [HttpGet]
    [Route("api/jugada/continuar/{idJug}+{idUsu}")]
    public async Task<ActionResult<RdoJugContinuar>> continuar(int idJug, int idUsu)
    {
        try
        {
            var rdo = new RdoJugContinuar();
            var part = await _context.Partida.Where(p => p.IdJugada.Equals(idJug) && p.Estado.Equals(0) &&
            p.IdJugadaNavigation.IdUsuario.Equals(idUsu) && p.IdJugadaNavigation.Estado.Equals(0)).
            OrderBy(p=> p.IdPartida).LastOrDefaultAsync();

            if (part != null)
            {
                var caj = await _context.Cartajugada.Where(c => c.IdPartida.Equals(part.IdPartida)).
                Include(p => p.IdCartaNavigation).ToListAsync();

                if (caj != null)
                {
                    foreach (var c in caj)
                    {
                        var rdoAux = new RdoUnicaCarta()
                        {
                            id = c.IdCarta,
                            carta = c.IdCartaNavigation.Carta,
                            valor = c.IdCartaNavigation.Valor,
                        };
                        rdo.cartasJugadas.Add(rdoAux);
                    }
                    rdo.idJugada = part.IdPartida;
                    rdo.puntosJug = part.PuntosJugador;
                    rdo.puntosCrup = part.PuntosCrupier;
                }
                else
                {
                    return Ok("No hay partidas disponibles");
                }
            }
            else
            {
             
                return Ok("No hay jugadas disponibles");
            }
            return Ok(rdo);
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

    [HttpGet]
    [Route("api/jugada/buscar/{idJug}+{idUsu}")]
    public async Task<ActionResult<RdoPartida>> getPartida(int idJug, int idUsu)
    {
        try
        {
            var rdo = new RdoPartida();
            var part = await _context.Partida.Where(p => p.IdJugada.Equals(idJug) && p.Estado.Equals(0) &&
            p.IdJugadaNavigation.IdUsuario.Equals(idUsu) && p.IdJugadaNavigation.Estado.Equals(0)).FirstOrDefaultAsync();

            if (part != null)
            {
                rdo.idPartida = part.IdPartida;
                if (part.Estado.Equals(0))
                {

                    var nueva = new Partidum()
                    {
                        IdJugada = idJug,
                        PuntosCrupier = 0,
                        PuntosJugador = 0,
                        Estado = 0,
                        Resultado = ""
                    };
                    await _context.AddAsync(nueva);

                    _context.SaveChanges();
                    rdo.idPartida = nueva.IdPartida;
                }
            }
            return Ok(rdo);
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

    [HttpGet]
    [Route("api/partidas/lista/{idUsu}")]
    public async Task<ActionResult<RdoListaPartida>> listaPartidas(int idUsu)
    {
        try
        {
            var result = new RdoListaPartida();
            
            var partidas = await _context.Partida.Where(j => j.IdJugadaNavigation.IdUsuario.Equals(idUsu)).ToListAsync();
            if (partidas != null)
            {
                foreach (var par in partidas)
                {
                    var resultAux = new RdoReporte()
                    {
                        idPartida = par.IdPartida,
                        IdJugada = par.IdJugada,
                        PuntosCrupier = par.PuntosCrupier,
                        PuntosJugador = par.PuntosJugador,
                        Estado= par.Estado,
                        Resultado = par.Resultado
                    };
                    result.listaPartida.Add(resultAux);
                }
                return Ok(result);
            }
            else
            {
                return Ok(result);
            }
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

     [HttpGet]
    [Route("api/partidas/lista/ganadas")]
    public async Task<ActionResult<RdoPartidasGanadas>> listaPartidasGanadas()
    {
        try
        {
            var result = new RdoPartidasGanadas();
            var partidas = await _context.Partida.Where(p => p.Resultado!.Equals("Ganaste!")).
            Include(u => u.IdJugadaNavigation.IdUsuarioNavigation).ToListAsync();
            if (partidas != null)
            {
                foreach (var par in partidas)
                {
                    var resultAux = new Id()
                    {
                        IdUsuario=par.IdJugadaNavigation.IdUsuario,
                        Nombre = par.IdJugadaNavigation.IdUsuarioNavigation.Usuario1,
                 
                    };
                    result.listaUsuarios.Add(resultAux);
                }
                return Ok(result);
            }
            else
            {
                return Ok(result);
            }
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }





}