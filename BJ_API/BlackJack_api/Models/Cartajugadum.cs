using System;
using System.Collections.Generic;

namespace BlackJack_api.Models
{
    public partial class Cartajugadum
    {
        public int IdCartaJugada { get; set; }
        public int IdCarta { get; set; }
        public int IdPartida { get; set; }
        public string Jugador { get; set; } = null!;

        public virtual Cartum IdCartaNavigation { get; set; } = null!;
        public virtual Partidum IdPartidaNavigation { get; set; } = null!;
    }
}
