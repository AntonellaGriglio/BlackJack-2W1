namespace BlackJack_api.Resultados.Jugada;

public class RdoListaPartida
{

    public List<RdoReporte> listaPartida { get; set; } = new List<RdoReporte>();
}
public class RdoReporte
{
    public int idPartida { get; set; }
    public int IdJugada { get; set; }
    public int PuntosJugador { get; set; }
    public int PuntosCrupier { get; set; }
    public int Estado { get; set; }

     public string? Resultado { get; set; }


}
