import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { ErrorHandler } from '../Helpers/ErrorHandler';
import { LoginResponseDto } from '../modelos/LoginResponseDto';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private usuarioLogado: LoginResponseDto;;

  constructor(private http: HttpClient, private router: Router) { }

  get estaLogado(): LoginResponseDto {
    if (!this.usuarioLogado) {
      this.usuarioLogado = JSON.parse(localStorage.getItem('auth'));
    }
    return this.usuarioLogado;
  }

  setCookie(userData: LoginResponseDto) {
    localStorage.setItem('auth', JSON.stringify(userData));
    this.usuarioLogado = userData;
  }

  logout() {
    this.usuarioLogado = undefined;
    localStorage.removeItem('auth');
    this.router.navigate(['/login'])

  }


  Autenticar(user: string, senha: string): Observable<LoginResponseDto> {
    return this.http.post<LoginResponseDto>('http://localhost:5000/api/usuario/login', { user: user, senha: senha })
      .pipe(catchError(err => ErrorHandler.handle(err)), tap(r => this.setCookie(r)));

  }
  Cadastrar(user: string, senha: string, email: string): Observable<LoginResponseDto> {
    return this.http.post<LoginResponseDto>('http://localhost:5000/api/usuario/', { user: user, senha: senha, email: email })
      .pipe(catchError(err => ErrorHandler.handle(err)), tap(r => this.setCookie(r)));
  }

}
