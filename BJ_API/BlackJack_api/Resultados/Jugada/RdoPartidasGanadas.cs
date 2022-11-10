namespace BlackJack_api.Resultados.Jugada;

public class RdoPartidasGanadas{

public List<Id> listaUsuarios { get; set; } = new List<Id>();
}
public class Id{
    public int IdUsuario { get; set; }
    public string? Nombre { get; set; }
}