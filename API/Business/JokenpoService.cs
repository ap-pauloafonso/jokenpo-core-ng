using System;
using Business.Dtos;
using Business.Interfaces;
using Business.Modelos;
using System.Linq;
using System.Collections.Generic;

namespace Business
{
    public class JokenpoService : IJokenpoService
    {

        private IUnitOfWork unitofwork;
        public JokenpoService(IUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;
        }

        public JogadaResponseDto ComecarPartida(string userid, string escolha)
        {

            Partida partida = Partida.PrepararNovaPartida(userid);
            this.unitofwork.Partidas.Add(partida);
            PartidaDetalhe detalhe = PartidaDetalhe.PrepararDetalhe(partida.PartidaId, 1, escolha);
            this.unitofwork.Partidas.SalvarDetalhe(detalhe);
            this.unitofwork.commit();
            return new JogadaResponseDto()
            {
                resultado = detalhe.Resultado,
                partida = detalhe.PartidaId,
                round = detalhe.NumeroRound,
                escolhaJogador = detalhe.EscolhaJogador,
                escolhaComputador = detalhe.EscolhaComputador,
                PartidaWinDraw = this.unitofwork.Partidas.GetPartidaWinLossDraw(detalhe.PartidaId)
            };
        }

        public JogadaResponseDto jogar(int partidaid, int round, string escolha)
        {
            if (round > 10)
            {
                throw new Exception("Maximo de 10 rodas");
            }
            PartidaDetalhe detalhe = PartidaDetalhe.PrepararDetalhe(partidaid, round, escolha);
            this.unitofwork.Partidas.SalvarDetalhe(detalhe);
            this.unitofwork.commit();
            // this.unitofwork.Partidas.GetPartidaComDetalhes(partidaid).detalhes.Where(x)
            return new JogadaResponseDto()
            {
                resultado = detalhe.Resultado,
                partida = detalhe.PartidaId,
                round = detalhe.NumeroRound,
                escolhaJogador = detalhe.EscolhaJogador,
                escolhaComputador = detalhe.EscolhaComputador,
                PartidaWinDraw = this.unitofwork.Partidas.GetPartidaWinLossDraw(detalhe.PartidaId)
            };
        }

        public LoginResponseDto CriarUsuario(CriarUsuarioDto usuario)
        {
            if (this.unitofwork.Usuarios.ConsultarUsuarioPorEmail(usuario.email) != null || this.unitofwork.Usuarios.ConsultarUsuarioPorId(usuario.user) != null)
            {
                throw new Exception("INVALIDO");
            }

            this.unitofwork.Usuarios.Add(new Usuario()
            {
                UsuarioId = usuario.user,
                email = usuario.email,
                senha = usuario.senha,
                datahoracriacao = DateTime.Now

            });

            this.unitofwork.commit();
            return new LoginResponseDto() { user = usuario.user, email = usuario.email };
        }

        public LoginResponseDto login(string user, string senha)
        {
            var usu = this.unitofwork.Usuarios.find(x => x.UsuarioId == user && x.senha == senha).FirstOrDefault();
            if (usu == null)
            {
                throw new Exception("Login ou senha Invalidos");
            }
            else
            {
                return new LoginResponseDto() { user = user, email = usu.email };
            }
        }

        public IEnumerable<PartidaDetalheResponseDto> ConsultaPartida(int id)
        {
            var result = this.unitofwork.Partidas.GetPartidaComDetalhes(id);

            return result.detalhes.Select(x => new PartidaDetalheResponseDto()
            {
                round = x.NumeroRound,
                resultado = x.Resultado,
                escolhaComputador = x.EscolhaComputador,
                escolhaJogador = x.EscolhaJogador

            }).ToList();
        }
    }
}