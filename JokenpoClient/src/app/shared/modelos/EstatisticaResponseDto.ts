export interface EstatisticaResponseDto {
    user: string;
    partidasGanhas: number;
    partidasPerdidas: number;
    partidasEmpatadas: number;
    totalPartidas: number;
    porcentagemGanha: number;
}