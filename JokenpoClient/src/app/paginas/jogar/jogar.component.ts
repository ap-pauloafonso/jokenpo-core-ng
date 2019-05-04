import { Component, OnInit, ViewChild } from '@angular/core';
import { JokenPoService } from 'src/app/shared/joken-po.service';
import { CardJogadorModel } from 'src/app/componentes/card-jogador/card-jogador.model';
import { CardJogadorComponent } from 'src/app/componentes/card-jogador/card-jogador.component';
import { PlacarModel } from 'src/app/componentes/placar/placar.model';
import { MatDialog } from '@angular/material/dialog';
import { FinalPartidaComponent } from 'src/app/componentes/final-partida/final-partida.component';
import { AuthService } from 'src/app/shared/seguranca/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-jogar',
  templateUrl: './jogar.component.html',
  styleUrls: ['./jogar.component.css']
})

export class JogarComponent implements OnInit {

  constructor(private _jokenPoService: JokenPoService,
    public dialog: MatDialog,
    private router: Router,
    private _authService: AuthService) { }

  ngOnInit() {
  }


  @ViewChild('ComputadorComp') ComputadorComp: CardJogadorComponent;
  @ViewChild('JogadorComp') JogadorComp: CardJogadorComponent;


  jogador: CardJogadorModel = new CardJogadorModel(false, 'vazio', 'paulo');

  computador: CardJogadorModel = new CardJogadorModel(true, 'escolhido');

  placar: PlacarModel = new PlacarModel();



  handleAcaoRealizada(event: string) {
    if (this.computador.state == 'escolhido') {
      debugger;
      if (this.placar.roundAtual == 1) {
        this._jokenPoService.comecarPartida(this._authService.usuarioLogado, event)
          .subscribe(x => {
            debugger;
            this.placar.partida = x.partida;
            this.handleVisual(x.partidaWinDraw.winCount,
              x.partidaWinDraw.lossCount,
              x.escolhaComputador,
              x.escolhaJogador);

          }, err => {

          })

      } else if (this.placar.roundAtual <= 10) {
        this._jokenPoService.jogar(this.placar.partida, this.placar.roundAtual, event)
          .subscribe(x => {
            this.placar.partida = x.partida;
            this.handleVisual(x.partidaWinDraw.winCount,
              x.partidaWinDraw.lossCount,
              x.escolhaComputador,
              x.escolhaJogador);

          }, err => { })
      }
    }
  }

  handleVisual(quantidadeGanha: number, quantiadePerdida: number, escolhaComputador: string, escolhaJogador: string) {
    this.placar.quantidadeGanha = quantidadeGanha;
    this.placar.quantidadePerdida = quantiadePerdida;

    this.ComputadorComp.mostrarResposta(escolhaComputador);
    this.JogadorComp.mostrarResposta(escolhaJogador);

    setTimeout(() => {

      this.ComputadorComp.cardJogadorModel.state = 'pensando';
      setTimeout(() => { this.ComputadorComp.cardJogadorModel.state = 'escolhido' }, 300);
      this.JogadorComp.cardJogadorModel.state = 'vazio'


      if (this.placar.roundAtual == 10) {
        this.openDialog(this.placar);
      } else {
        this.placar.roundAtual = ++this.placar.roundAtual;

      }
    }, 2000);
  }

  openDialog(placar: PlacarModel): void {
    const dialogRef = this.dialog.open(FinalPartidaComponent, {
      width: '500',
      data: placar,
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result == 'cancel') {
        this.router.navigate(['/home']);
      } else {
        this.jogador = new CardJogadorModel(false, 'vazio', 'paulo');

        this.computador = new CardJogadorModel(true, 'escolhido');

        this.placar = new PlacarModel();

      }
    });
  }

}
