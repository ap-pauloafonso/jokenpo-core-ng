import { Component, OnInit } from '@angular/core';
import { JokenPoService } from 'src/app/shared/joken-po.service';
import { EstatisticaResponseDto } from 'src/app/shared/modelos/EstatisticaResponseDto';
import { forkJoin } from 'rxjs';
import { AuthService } from 'src/app/shared/seguranca/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private service: JokenPoService,
    public authService: AuthService,
    public router :Router
    ) { }

  ranking: EstatisticaResponseDto[];
  user: EstatisticaResponseDto;

  displayedColumns: string[] =
    ['position', 'user', 'partidasGanhas', 'partidasPerdidas', 'partidasEmpatadas', 'porcentagemGanha'];
  ngOnInit() {
    forkJoin(this.service.getRanking(), this.service.getEstatisticaUsuario(this.authService.estaLogado.user))
      .subscribe(([ranking, user]) => {
        this.ranking = ranking;
        this.user = user;
      })
  }

}
