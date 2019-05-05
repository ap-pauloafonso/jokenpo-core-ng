using Business.Modelos;

namespace Business.Interfaces
{
    public interface IPartidaRepositorio : IRepositorioBase<Partida>
    {
        void SalvarDetalhe(PartidaDetalhe detlhe);
        Partida GetPartidaComDetalhes(int Partida);

        PartidaWinLossDraw GetPartidaWinLossDraw(int PartidaId);



    }
}