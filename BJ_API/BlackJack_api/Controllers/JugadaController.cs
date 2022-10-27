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

    //LISTORTI
    //USO-> "ultimas partidas"
    [HttpGet]
    [Route("api/jugada/lista/{idUsu}")]
    public async Task<ActionResult<RdoJugadas>> listaJugadas(int idUsu)
    {
        try
        {
            var result = new RdoJugadas();
            //var usuario = await _context.Usuarios.Where(c => c.IdUsuario.Equals(idUsu)).FirstOrDefaultAsync();
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

    //NO ANDAAA
    /*[HttpGet]
    [Route("api/partida/continuar/{idJugada}+{idUsu}")]
    public async Task<ActionResult<RdoJugContinuar>> getJugadaId(int idJugada, int idUsu)
    {
        try
        {
            var cartasJugadas = await _context.Cartajugada.ToListAsync();
            var carta = await _context.Carta.ToListAsync();
            var partida = await _context.Partida.Where(p => p.IdJugada.Equals(idJugada)
            && p.IdJugadaNavigation.IdUsuario.Equals(idUsu) && p.Estado.Equals(0)).OrderBy(p => p.IdPartida).
            ToListAsync();

            var result = new RdoJugContinuar();

            var query = from caj in cartasJugadas
                        join car in carta on caj.IdCarta equals car.IdCarta into table1
                        from car in table1.DefaultIfEmpty()
                        join part in partida on caj.IdPartida equals part.IdPartida into table2
                        from part in table2.DefaultIfEmpty()
                            //orderby part.IdPartida descending
                        select new JoinClass { getPartidas = part, getCartaJ = caj, carta = car };

            Console.WriteLine(query);

            foreach (var q in query)
            {
                foreach (var c in q.getPartidas.Cartajugada)
                {
                    var rdoAux = new RdoUnicaCarta()
                    {
                        id = c.IdCarta,
                        carta = c.IdCartaNavigation.Carta,
                        valor = c.IdCartaNavigation.Valor
                    };
                    result.cartasJugadas.Add(rdoAux);
                }
                result.puntosJug = q.getPartidas.PuntosCrupier;
                result.puntosCrup = q.getPartidas.PuntosCrupier;
                result.idJugada = q.getPartidas.IdJugada;
                result.usuario = q.getPartidas.IdJugadaNavigation.IdUsuarioNavigation.Usuario1;
            }

            return result;
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }*/

    //LISTORTI
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
                /*var nueva = new Partidum()
                {
                    IdJugada = idJug,
                    PuntosCrupier = 0,
                    PuntosJugador = 0,
                    Estado = 0,
                    Resultado = ""
                };
                await _context.AddAsync(nueva);
                _context.SaveChanges();
                rdo.idJugada = nueva.IdPartida;
                rdo.puntosJug = 0;
                rdo.puntosCrup = 0;*/
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
}