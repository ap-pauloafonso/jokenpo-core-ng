
using System;
using System.Collections.Generic;

namespace Business.Modelos
{
    public class PartidaDetalhe
    {
        public int NumeroRound { get; set; }

        public int PartidaId { get; set; }

        public string EscolhaJogador { get; set; }

        public string EscolhaComputador { get; set; }

        public string Resultado { get; set; }

        public static PartidaDetalhe PrepararDetalhe(int partidaId, int round, string escolha)
        {
            var ret = new PartidaDetalhe()
            {
                NumeroRound = round,
                PartidaId = partidaId,
                EscolhaComputador = resultadoComputador,
                EscolhaJogador = escolha,
            };
            ret.Resultado = resultadoFinal(ret.EscolhaJogador, ret.EscolhaComputador);

            return ret;
        }
        private static string resultadoFinal(string escolhaJogador, string EscolhaComputador)
        {
            if (escolhaJogador == EscolhaComputador) return "draw";

            if (escolhaJogador == "pedra" && EscolhaComputador == "papel") return "loss";
            if (escolhaJogador == "papel" && EscolhaComputador == "tesoura") return "loss";
            if (escolhaJogador == "tesoura" && EscolhaComputador == "pedra") return "loss";

            if (EscolhaComputador == "pedra" && escolhaJogador == "papel") return "win";
            if (EscolhaComputador == "papel" && escolhaJogador == "tesoura") return "win";
            if (EscolhaComputador == "tesoura" && escolhaJogador == "pedra") return "win";
            return "";
        }
        private static string resultadoComputador
        {
            get
            {
                var escolhasDisponiveis = new List<string>() { "pedra", "papel", "tesoura" };
                var ret = escolhasDisponiveis[new Random().Next(3)];
                return ret;

            }
        }
    }
}