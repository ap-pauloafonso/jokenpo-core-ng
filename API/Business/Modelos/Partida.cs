using System;
using System.Collections;
using System.Collections.Generic;

namespace Business.Modelos
{
    public class Partida
    {
        public int PartidaId { get; set; }
        public string UsuarioId { get; set; }
        public DateTime datahorainicio { get; set; }
        public DateTime? datahorafim { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<PartidaDetalhe> detalhes { get; set; }
        public static Partida PrepararNovaPartida(string userid)
        {
            return new Partida()
            {
                UsuarioId = userid,
                datahorainicio = DateTime.Now,
            };
        }
    }
}