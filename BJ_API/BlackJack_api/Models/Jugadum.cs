using System;
using System.Collections.Generic;

namespace BlackJack_api.Models
{
    public partial class Jugadum
    {
        public Jugadum()
        {
            Partida = new HashSet<Partidum>();
        }

        public int IdJugada { get; set; }
        public int IdUsuario { get; set; }
        public int Estado { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual ICollection<Partidum> Partida { get; set; }
    }
}
