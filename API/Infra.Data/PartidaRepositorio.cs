using System.Linq;
using Business.Interfaces;
using Business.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class PartidaRepositorio : RepositorioBase<Partida>, IPartidaRepositorio
    {
        public JokenpoContext JokenpoContext
        {
            get { return Context as JokenpoContext; }
        }

        public PartidaRepositorio(JokenpoContext context) : base(context)
        {
        }
        public Partida GetPartidaComDetalhes(int Partida)
        {
            return JokenpoContext.Partida.Include(e => e.detalhes).Where(x => x.PartidaId == Partida).FirstOrDefault();
        }

        public void SalvarDetalhe(PartidaDetalhe detlhe)
        {
            JokenpoContext.PartidaDetalhe.Add(detlhe);
        }

        public PartidaWinLossDraw GetPartidaWinLossDraw(int partida)
        {
            var detalhes = GetPartidaComDetalhes(partida).detalhes;

            return new PartidaWinLossDraw()
            {
                winCount = detalhes.Where(x => x.Resultado == "win").Count(),
                lossCount = detalhes.Where(x => x.Resultado == "loss").Count(),
                drawCount = detalhes.Where(x => x.Resultado == "win").Count(),

            };
        }
    }
}