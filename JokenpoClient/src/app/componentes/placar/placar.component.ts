import { Component, OnInit, Input } from '@angular/core';
import { PlacarModel } from './placar.model';

@Component({
  selector: 'placar',
  templateUrl: './placar.component.html',
  styleUrls: ['./placar.component.css']
})



export class PlacarComponent implements OnInit {

  @Input() placarModel: PlacarModel
  constructor() { }

  ngOnInit() {
  }

}
