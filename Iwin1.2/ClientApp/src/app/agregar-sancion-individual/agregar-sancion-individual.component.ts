import { Component, OnInit, Input, ViewChild, Inject } from '@angular/core';
import { jugadorservice } from '../Service/jugadorservice';
import { Juego } from '../Domain/juego.model';
import { Campeonato } from '../Domain/Campeonato.model';
import { SancionEquipoComponent } from '../sancion-equipo/sancion-equipo.component';
import { SancionColectiva } from '../Domain/sancionColectiva.model';
import { Resultado } from '../Domain/resultado.model';
import { HttpClient } from '@angular/common/http';
import { Equipo } from '../Domain/Equipo.model';
import { SancionIndividualService } from '../Service/sancionIndividual.service';
import { SancionIndividual } from '../Domain/sancionIndividual.model';
import { SancionIndividualComponent } from '../sancion-individual/sancion-individual.component';

@Component({
  selector: 'app-agregar-sancion-individual',
  templateUrl: './agregar-sancion-individual.component.html',
  styleUrls: ['./agregar-sancion-individual.component.css']
})
export class AgregarSancionIndividualComponent implements OnInit {

  idEquipo: number = 1;
  campeonaatoSelecto: number;
  public campeonatos: Campeonato[];
  public juegos: Juego[];
  public juegosSelectos: boolean;
  sancionC: SancionIndividual;
  public juego: Juego;
  resultadoA: Resultado;
  public sanciones: SancionIndividual[] = [];
  public sancionesExistentes: boolean;
  @ViewChild('actualiza') actualizarCom: SancionIndividualComponent;
  @ViewChild('actualiza2') actualizarCom2: SancionIndividualComponent;

  constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string, private SancionIndividualService: SancionIndividualService) {

    this.SancionIndividualService.getCampeonatos().subscribe(data => this.campeonatos = data);

  }

  ngOnInit() {



  }



  seleccionar() {
    this.SancionIndividualService.getJuegos(this.campeonaatoSelecto).subscribe(data => this.juegos = data);;


    this.juegosSelectos = false;


  }


  seleccionaJuego(juego: Juego) {
    this.juego = juego;
    this.juegosSelectos = true;

    this.http.get<Resultado>(this.baseUrl + 'api/resultado/' + this.juego.identificador + "/" + this.idEquipo).subscribe(result => {
      this.resultadoA = result;
    }, error => console.error(error));










  }

  getsanciones() {
    for (var _i = 0; _i < this.resultadoA.sancionesColectivas; _i++) {

      this.sanciones.push(new SancionIndividual());
    }
    return this.sanciones;

  }


  guardarSanciones() {
    if (this.actualizarCom != null) {
      if (this.actualizarCom2 != null) {
        if (this.actualizarCom.validar() && this.actualizarCom2.validar()) {
          alert("todo listo");

          for (var _i = 0; _i < this.actualizarCom.sanciones.length; _i++) {
            this.SancionIndividualService.guardarSancion(this.actualizarCom.sanciones[_i]).subscribe(data => this.sancionC = data);

          }
          for (var _i = 0; _i < this.actualizarCom2.sanciones.length; _i++) {
            this.SancionIndividualService.guardarSancion(this.actualizarCom2.sanciones[_i]).subscribe(data => this.sancionC = data);

          }

         // window.location.reload();

        }
        else {

          alert("Aun quedan sanciones por registrar");

        }
      }

    }


  }

}
