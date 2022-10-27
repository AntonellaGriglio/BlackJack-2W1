namespace BlackJack_api.Controllers;

using BlackJack_api.Comandos.Cartas;
using BlackJack_api.Models;
using BlackJack_api.Resultados.Mazo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CartaController : ControllerBase
{
    private readonly blackjackContext _context;

    public CartaController(blackjackContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/juego/mazo")]
    public async Task<ActionResult<RdoMazo>> getCartas()
    {
        try
        {
            var result = new RdoMazo();
            var cartas = await _context.Carta.ToListAsync();

            if (cartas != null)
            {
                foreach (var carta in cartas)
                {
                    var resultAux = new RdoCarta
                    {
                        id = carta.IdCarta,
                        valor = carta.Valor,
                        carta = carta.Carta,
                        isAs = carta.IsAs
                    };
                    result.mazo.Add(resultAux);

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
    [Route("api/mazo/getCartaxId/{idCart}")]
    public async Task<ActionResult<RdoUnicaCarta>> getById(int idCart)
    {
        try
        {
            var result = new RdoUnicaCarta();
            var carta = await _context.Carta.Where(c => c.IdCarta.Equals(idCart)).FirstOrDefaultAsync();

            if (carta != null)
            {
                result.id = carta.IdCarta;
                result.carta = carta.Carta;
                result.valor = carta.Valor;
            }
            return result;
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }

    [HttpPost]
    [Route("api/cartaJugada/post/{idPart}+{idJug}")]
    public async Task<ActionResult<bool>> cartaJugada([FromBody] CmdCartaJugada cmd, int idPart, int idJug)
    {
        try
        {
            var part = await _context.Partida.Where(p => p.IdPartida.Equals(idPart) && p.IdJugada.Equals(idJug)).
            Include(j => j.IdJugadaNavigation).OrderBy(p => p.IdPartida).LastOrDefaultAsync();

            if (part != null && part.Estado.Equals(0))
            {
                var cartaJugada = new Cartajugadum()
                {
                    IdCarta = cmd.idCarta,
                    IdPartida = idPart,
                    Jugador = cmd.jugador,
                };

                await _context.AddAsync(cartaJugada);
                await _context.SaveChangesAsync();

                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        catch (Exception e)
        {
            return BadRequest("No se puede realizar esta acción");
        }
    }
}