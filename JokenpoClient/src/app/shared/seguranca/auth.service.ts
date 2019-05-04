import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  usuarioLogado: string;

  constructor(private http: HttpClient) { }

  get estaLogado(): string {
    if (!this.usuarioLogado) {
      this.usuarioLogado = localStorage.getItem('auth');
    }
    return this.usuarioLogado;
  }

  setCookie() {
    localStorage.setItem('auth', 'paulo')
  }

  logout() {
    this.usuarioLogado = undefined;
    localStorage.removeItem('username');
  }


  Autenticar(user: string, senha: string): Observable<any> {
    return this.http.post('http://localhost:5000/api/usuario/login', { user: user, senha: senha });
  }
  Cadastrar(user: string, senha: string, email: string): Observable<any> {
    return this.http.post('http://localhost:5000/api/usuario/', { user: user, senha: senha, email: email });

  }

}
