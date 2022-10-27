namespace BlackJack_api.Resultados.Jugada;

public class RdoJugadas
{
    public List<RdoJuego> listaJugadas { get; set; } = new List<RdoJuego>();
}

public class RdoJuego
{
    public int idJugada { get; set; }
    public string usuario { get; set; }
}