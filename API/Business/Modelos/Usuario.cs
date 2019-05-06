using System;
using System.Collections.Generic;

namespace Business.Modelos
{
    public class Usuario
    {
        public Usuario()
        {
            partidas = new List<Partida>();
        }
        public string UsuarioId { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public DateTime datahoracriacao { get; set; }

        public DateTime? datahoraconfirmacao { get; set; }
        public IEnumerable<Partida> partidas { get; }

    }

}