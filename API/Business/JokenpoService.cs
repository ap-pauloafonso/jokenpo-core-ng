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

        private const int NUMERO_MAXIMO_ROUNDS = 10;
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
            if (round > NUMERO_MAXIMO_ROUNDS)
            {
                throw new JokenpoBusinessException("Não é possivel jogar mais que 10 rounds por partida");
            }
            PartidaDetalhe detalhe = PartidaDetalhe.PrepararDetalhe(partidaid, round, escolha);
            this.unitofwork.Partidas.SalvarDetalhe(detalhe);


            if (round == NUMERO_MAXIMO_ROUNDS)
            {
                var partidasDetalherDoBanco = this.unitofwork.Partidas.GetPartidaComDetalhes(partidaid);
                partidasDetalherDoBanco.TerminarPartida();

            }
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
            if (this.unitofwork.Usuarios.ConsultarUsuarioPorId(usuario.user) != null)
            {
                throw new JokenpoBusinessException("Já existe um usuario com esse nome");
            }
            if (this.unitofwork.Usuarios.ConsultarUsuarioPorEmail(usuario.email) != null)
            {
                throw new JokenpoBusinessException("Já existe um usuario com esse email");
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
                throw new JokenpoBusinessException("Login ou senha Invalidos");
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

        public IEnumerable<EstatisticasUsuario> ConsultaRanking(int limite)
        {

            return this.unitofwork.Usuarios.ConsultarUsuariosComPartidas()
             .Select(s => new EstatisticasUsuario(
             this.unitofwork.Usuarios.ConsultarUsuarioPorId(s.UsuarioId)?.UsuarioId,
             s.partidas.Count(x => x.resultado == "win"),
             s.partidas.Count(x => x.resultado == "loss"),
             s.partidas.Count(x => x.resultado == "draw"),
             s.partidas.Count()
             ))
             .OrderByDescending(x => x.porcentagemGanha)
             .Take(limite)
             .ToList();

        }

        public EstatisticasUsuario ConsultaEstatisticaUsuario(string user)
        {
            var usuario = this.unitofwork.Usuarios.ConsultarUsuariosComPartidas(user)
            .FirstOrDefault();

            return new EstatisticasUsuario(usuario.UsuarioId,
             usuario.partidas.Count(x => x.resultado == "win"),
             usuario.partidas.Count(x => x.resultado == "loss"),
             usuario.partidas.Count(x => x.resultado == "draw"),
             usuario.partidas.Count() 
            );
        }
    }
}