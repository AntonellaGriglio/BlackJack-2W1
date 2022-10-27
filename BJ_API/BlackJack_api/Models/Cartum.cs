using System;
using System.Collections.Generic;

namespace BlackJack_api.Models
{
    public partial class Cartum
    {
        public Cartum()
        {
            Cartajugada = new HashSet<Cartajugadum>();
        }

        public int IdCarta { get; set; }
        public int Valor { get; set; }
        public string Carta { get; set; } = null!;
        public bool IsAs { get; set; }

        public virtual ICollection<Cartajugadum> Cartajugada { get; set; }
    }
}
