import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EliminarJugadorComponent } from './eliminar-jugador.component';

describe('EliminarJugadorComponent', () => {
  let component: EliminarJugadorComponent;
  let fixture: ComponentFixture<EliminarJugadorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EliminarJugadorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EliminarJugadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
