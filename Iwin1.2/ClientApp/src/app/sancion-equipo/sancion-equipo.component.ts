import { Component, OnInit, Input, Inject } from '@angular/core';
import { SancionColectiva } from '../Domain/sancionColectiva.model';
import { Resultado } from '../Domain/resultado.model';
import { SancionColectivaService } from '../Service/sancion-colectiva.service';
import { Juego } from '../Domain/juego.model';
import { HttpClient } from '@angular/common/http';
import { Equipo } from '../Domain/Equipo.model';

@Component({
  selector: 'app-sancion-equipo',
  templateUrl: './sancion-equipo.component.html',
  styleUrls: ['./sancion-equipo.component.css']
})
export class SancionEquipoComponent implements OnInit {
  @Input() idEquipo: number;
  @Input() idJuego: number;
  equipo: Equipo;
  total: number=5;
  conteo: number = 1;
  tipo: string;
  motivo: string;
  public sanciones: SancionColectiva[] = [];
  public resultadoA: Resultado = new Resultado();
  public sancionesExistentes: boolean;
  juego: Juego;

  constructor(private http: HttpClient, @Inject('BASE_URL') public baseUrl: string,private SancionColectivaService: SancionColectivaService) {

 




  }
  sancionC: SancionColectiva;
  agregar() {

    this.sancionC = new SancionColectiva(0, this.idJuego, this.idEquipo, this.tipo, this.motivo);
    this.tipo = "";
    this.motivo = "";
    this.sanciones.push(this.sancionC);
    alert("Se a ingresado correctamente")
  }



  ngOnInit() {

    console.log(this.baseUrl + "api/resultado/equipo/" + this.idEquipo+"  fjnjfhjdsbjb")
    this.http.get<Equipo>(this.baseUrl + "api/resultado/equipo/" + this.idEquipo).subscribe(result => {
      this.equipo = result;
    }, error => console.error(error));

    console.log(this.baseUrl + 'api/resultado/' + this.idJuego + "/" + this.idEquipo)
    this.http.get<Resultado>(this.baseUrl + 'api/resultado/' + this.idJuego +"/"+ this.idEquipo).subscribe(result => {
      this.resultadoA = result;
    }, error => console.error(error));

   

  }



  getsanciones() {
    for (var _i = 0; _i < this.resultadoA.sancionesColectivas; _i++) {

      this.sanciones.push(new SancionColectiva());
    }
    return this.sanciones;


  }
  datoscorrectos: boolean;
  guardar() {
    this.datoscorrectos=true;
    for (var _i = 0; _i < this.sanciones.length; _i++) {

      if (this.sanciones[_i].tipo == "" || this.sanciones[_i].motivo == "" ) {
        this.datoscorrectos = false;

      }
      
    }
    if (this.datoscorrectos) {



    }


  }

}
