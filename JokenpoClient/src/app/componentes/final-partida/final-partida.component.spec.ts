import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinalPartidaComponent } from './final-partida.component';

describe('FinalPartidaComponent', () => {
  let component: FinalPartidaComponent;
  let fixture: ComponentFixture<FinalPartidaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinalPartidaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinalPartidaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
