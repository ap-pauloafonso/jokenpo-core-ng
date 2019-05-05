import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { JogadaResponseDto } from './modelos/JogadaResponseDTO';
import { PartidaDetalheResponseDto } from './modelos/PartidaDetalheResponseDto'
import { HttpClient } from '@angular/common/http';
import { ErrorHandler } from './Helpers/ErrorHandler';
import { catchError } from 'rxjs/operators';
import { EstatisticaResponseDto } from './modelos/EstatisticaResponseDto';




@Injectable({
  providedIn: 'root'
})
export class JokenPoService {

  constructor(
    private http: HttpClient) { }

  comecarPartida(user: string, escolha: string): Observable<JogadaResponseDto> {
    return this.http.post<JogadaResponseDto>('http://localhost:5000/api/jogar/comecar', { user: user, escolha: escolha })
      .pipe(catchError(ErrorHandler.handle));
  }
  jogar(partida: number, round: number, escolha: string): Observable<JogadaResponseDto> {
    return this.http.post<JogadaResponseDto>('http://localhost:5000/api/jogar/', { partida: partida, round: round, escolha: escolha })
      .pipe(catchError(ErrorHandler.handle));

  }

  GetResultadoFinal(partida: number): Observable<PartidaDetalheResponseDto[]> {
    return this.http.get<PartidaDetalheResponseDto[]>('http://localhost:5000/api/jogar/partida/' + partida)
      .pipe(catchError(ErrorHandler.handle));

  }


  getRanking():Observable<EstatisticaResponseDto[]>{
    return this.http.get<EstatisticaResponseDto[]>('http://localhost:5000/api/estatisticas')
    .pipe(catchError(ErrorHandler.handle));
  }
  getEstatisticaUsuario(user:string):Observable<EstatisticaResponseDto>{
    return this.http.get<EstatisticaResponseDto>('http://localhost:5000/api/estatisticas/'+user)
    .pipe(catchError(ErrorHandler.handle));
  }
}
