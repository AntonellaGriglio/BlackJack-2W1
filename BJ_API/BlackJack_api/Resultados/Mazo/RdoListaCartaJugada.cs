namespace BlackJack_api.Resultados.Mazo;

public class RdoListaCartaJugada 
{
    
    public List<RdoCartaJugada> listaCartaJugadas { get; set; } = new List<RdoCartaJugada>();

}
public class RdoCartaJugada{
    public int IdCartaJugada { get; set; }
        
    public int IdCarta { get; set; }
    public string Carta { get; set; } = null!;
}