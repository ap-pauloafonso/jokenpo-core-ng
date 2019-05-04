using System;

namespace Business.Modelos
{
    public class Usuario
    {
        public string UsuarioId { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public DateTime datahoracriacao { get; set; }

        public DateTime datahoraconfirmacao { get; set; }

    }

}