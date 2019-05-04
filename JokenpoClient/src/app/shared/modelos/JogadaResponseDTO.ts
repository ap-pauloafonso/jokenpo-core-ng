export interface JogadaResponseDto {
    escolhaComputador: string,
    escolhaJogador: string,
    resultado: string;
    round: number;
    partida: number;

    partidaWinDraw: PartidaWinLossDraw

}


export interface PartidaWinLossDraw {
    winCount: number;
    lossCount: number;
    drawCount: number;

}