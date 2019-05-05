using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public string resultado { get; set; }

        public void TerminarPartida()
        {
            int win = detalhes.Where(x => x.Resultado == "win").Count();
            int loss = detalhes.Where(x => x.Resultado == "loss").Count();
            int draw = detalhes.Where(x => x.Resultado == "draw").Count();
            resultado = win == loss ? "draw" : win > loss ? "win" : "loss";
            datahorafim = DateTime.Now;
        }
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