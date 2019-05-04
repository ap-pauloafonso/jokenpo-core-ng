import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { of, } from 'rxjs';
import { JogadaResponseDto } from './modelos/JogadaResponseDTO';
import { PartidaDetalheResponseDto } from './modelos/PartidaDetalheResponseDto'
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class JokenPoService {

  constructor(
    private http: HttpClient) { }

  comecarPartida(user: string, escolha: string): Observable<JogadaResponseDto> {
    console.log(user, escolha)
    return this.http.post<JogadaResponseDto>('http://localhost:5000/api/jogar/comecar', { user: user, escolha: escolha });
  }
  jogar(partida: number, round: number, escolha: string): Observable<JogadaResponseDto> {
    console.log(partida, round, escolha)

    return this.http.post<JogadaResponseDto>('http://localhost:5000/api/jogar/', { partida: partida, round: round, escolha: escolha });
  }

  GetResultadoFinal(partida: number): Observable<PartidaDetalheResponseDto[]> {

    let array: PartidaDetalheResponseDto[];

    return this.http.get<PartidaDetalheResponseDto[]>('http://localhost:5000/api/jogar/partida/' + partida);
  }
}
