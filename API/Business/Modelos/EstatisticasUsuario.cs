using Business.Modelos;

namespace Business.Modelos
{
    public class EstatisticasUsuario
    {
        public string user { get; set; }
        public int partidasGanhas { get; set; }
        public int partidasPerdidas { get; set; }
        public int partidasEmpatadas { get; set; }

        public decimal totalPartidas { get; set; }

        public EstatisticasUsuario(string user, int partidasGanhas, int partidasPerdidas, int partidasEmpatadas, int totalPartidas)
        {
            this.user = user;
            this.partidasGanhas = partidasGanhas;
            this.partidasPerdidas = partidasPerdidas;
            this.partidasEmpatadas = partidasEmpatadas;
            this.totalPartidas = totalPartidas;
        }


        public decimal porcentagemGanha
        {
            get
            {
                return totalPartidas == 0 ? 0 :
                (((decimal)partidasGanhas + (0.5M * (decimal)partidasEmpatadas)) / (decimal)totalPartidas) * 100;
            }
        }

    }
}