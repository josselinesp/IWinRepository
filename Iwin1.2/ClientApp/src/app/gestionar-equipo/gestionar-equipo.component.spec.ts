import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionarEquipoComponent } from './gestionar-equipo.component';

describe('GestionarEquipoComponent', () => {
  let component: GestionarEquipoComponent;
  let fixture: ComponentFixture<GestionarEquipoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GestionarEquipoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionarEquipoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
