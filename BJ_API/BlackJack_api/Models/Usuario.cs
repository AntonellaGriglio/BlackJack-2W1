using System;
using System.Collections.Generic;

namespace BlackJack_api.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Jugada = new HashSet<Jugadum>();
        }

        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Jugadum> Jugada { get; set; }
    }
}
