using System;
using Business.Dtos;
using System.Collections.Generic;
using Business.Modelos;

namespace Business.Interfaces
{
    public interface IJokenpoService
    {
        JogadaResponseDto ComecarPartida(string userid, string escolha);
        JogadaResponseDto jogar(int partidaid, int round, string escolha);
        LoginResponseDto login(string user, string senha);
        LoginResponseDto CriarUsuario(CriarUsuarioDto usuario);

        void ConfirmarUsuario(string user, DateTime data);
        IEnumerable<PartidaDetalheResponseDto> ConsultaPartida(int id);
        IEnumerable<EstatisticasUsuario> ConsultaRanking(int limite);
        EstatisticasUsuario ConsultaEstatisticaUsuario(string user);

    }

}