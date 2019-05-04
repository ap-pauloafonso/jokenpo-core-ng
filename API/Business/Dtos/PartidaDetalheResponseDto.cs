using System.Linq;

namespace Business.Dtos
{
    public class PartidaDetalheResponseDto
    {
        public int round { get; set; }
        public string escolhaJogador { get; set; }
        public string escolhaComputador { get; set; }
        public string resultado { get; set; }

    }


}