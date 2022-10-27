namespace BlackJack_api.Resultados.Mazo;

public class RdoMazo
{
    public List<RdoCarta> mazo { get; set; } = new List<RdoCarta>();
}

public class RdoCarta
{
    public int id { get; set; }
    public int valor { get; set; }
    public string carta { get; set; }
    public bool isAs { get; set; }
}