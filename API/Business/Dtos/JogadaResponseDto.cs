using Business.Modelos;

namespace Business.Dtos
{
    public class JogadaResponseDto
    {
        public int round { get; set; }
        public string resultado { get; set; }
        public string escolhaJogador { get; set; }
        public string escolhaComputador { get; set; }

        public PartidaWinLossDraw PartidaWinDraw{ get; set; }
        public int partida { get; set; }
    }
}