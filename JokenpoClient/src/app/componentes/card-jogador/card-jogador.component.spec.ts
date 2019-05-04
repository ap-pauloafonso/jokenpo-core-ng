import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardJogadorComponent } from './card-jogador.component';

describe('CardComputadorComponent', () => {
  let component: CardJogadorComponent;
  let fixture: ComponentFixture<CardJogadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardJogadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardJogadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
