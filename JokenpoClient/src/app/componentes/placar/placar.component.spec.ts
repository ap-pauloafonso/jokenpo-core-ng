import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlacarComponent } from './placar.component';

describe('PlacarComponent', () => {
  let component: PlacarComponent;
  let fixture: ComponentFixture<PlacarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlacarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlacarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
