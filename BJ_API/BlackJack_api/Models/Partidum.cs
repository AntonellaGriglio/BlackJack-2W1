using System;
using System.Collections.Generic;

namespace BlackJack_api.Models
{
    public partial class Partidum
    {
        public Partidum()
        {
            Cartajugada = new HashSet<Cartajugadum>();
        }

        public int IdPartida { get; set; }
        public int IdJugada { get; set; }
        public int PuntosJugador { get; set; }
        public int PuntosCrupier { get; set; }
        public int Estado { get; set; }
        public string? Resultado { get; set; }

        public virtual Jugadum IdJugadaNavigation { get; set; } = null!;
        public virtual ICollection<Cartajugadum> Cartajugada { get; set; }
    }
}
