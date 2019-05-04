using System;
using Business.Dtos;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IJokenpoService
    {
        JogadaResponseDto ComecarPartida(string userid, string escolha);
        JogadaResponseDto jogar(int partidaid, int round, string escolha);
        LoginResponseDto login(string user, string senha);
        LoginResponseDto CriarUsuario(CriarUsuarioDto usuario);

        IEnumerable<PartidaDetalheResponseDto> ConsultaPartida(int id);
    }

}