import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CardJogadorModel } from './card-jogador.model';

@Component({
  selector: 'card-jogador',
  templateUrl: './card-jogador.component.html',
  styleUrls: ['./card-jogador.component.css']
})

export class CardJogadorComponent implements OnInit {


  // @Input() isBoot: boolean = true;
  // @Input() state: 'pedra' | 'papel' | 'tesoura' | 'pensando' | 'escolhido';
  // @Input() user: string;
  @Input() cardJogadorModel: CardJogadorModel
  @Output() acaoRealizada = new EventEmitter();
  constructor() { }

  ngOnInit() {

  }


  handleAcao(event) {
    if (!this.cardJogadorModel.isBoot) {
      this.acaoRealizada.emit(event);
    }
  }




  cardPensado() {
  }
  mostrarResposta(resposta: string, callback: () => void = undefined) {
    this.cardJogadorModel.state = resposta;

    if (callback) callback();
  }

}
