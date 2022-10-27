namespace BlackJack_api.Resultados.Jugada;
using BlackJack_api.Resultados.Mazo;

public class RdoJugContinuar
{
    public List<RdoUnicaCarta> cartasJugadas { get; set; } = new List<RdoUnicaCarta>();
    public int puntosJug { get; set; }
    public int puntosCrup { get; set; }
    public int idJugada { get; set; }
    
    //public string usuario { get; set; } = "";
}
