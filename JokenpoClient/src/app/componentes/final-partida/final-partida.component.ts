import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { JokenPoService } from 'src/app/shared/joken-po.service';
import { PartidaDetalheResponseDto } from 'src/app/shared/modelos/PartidaDetalheResponseDto';
import { PlacarModel } from '../placar/placar.model';

@Component({
  selector: 'app-final-partida',
  templateUrl: './final-partida.component.html',
  styleUrls: ['./final-partida.component.css']
})
export class FinalPartidaComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<FinalPartidaComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PlacarModel,
    private jokenPoService: JokenPoService) { }
  leftDatasource: PartidaDetalheResponseDto[];
  rightDatasource: PartidaDetalheResponseDto[];

  displayedColumns: string[] = ['round', 'escolhaJogador', 'escolhaComputador']

  ngOnInit() {
    this.jokenPoService.GetResultadoFinal(this.data.partida).subscribe(success => {
      this.leftDatasource = success;
      this.rightDatasource = this.leftDatasource.splice(0, Math.floor(this.leftDatasource.length / 2));
    })
  }

  getClassIcon(jogada: string, resultado: string, isBoot: boolean): string {
    let css = 'far ';
    debugger;
    switch (jogada) {
      case 'tesoura': css += 'fa-hand-scissors '; break;
      case 'papel': css += 'fa-hand-paper '; break;
      case 'pedra': css += 'fa-hand-rock '; break;
    }
    // css += !isBoot ? (resultado == 'win' ? 'ganho' : null) : null;
    return css;
  }

}
