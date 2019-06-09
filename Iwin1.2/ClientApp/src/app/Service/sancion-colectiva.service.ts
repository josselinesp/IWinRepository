import { Injectable, Inject } from '@angular/core';
import { Campeonato } from '../Domain/Campeonato.model';
import { Observable } from 'rxjs/Observable';
import { Juego } from '../Domain/juego.model';
import { Resultado } from '../Domain/resultado.model';
import { Equipo } from '../Domain/Equipo.model';
import { SancionColectiva } from '../Domain/sancionColectiva.model';
import { Http, RequestOptions, Headers } from '@angular/http'
import { Response } from '@angular/http';

import "rxjs/add/operator/map";
import { DatePipe } from '@angular/common';
@Injectable()
export class SancionColectivaService {

  constructor(private http: Http, @Inject('BASE_URL') public url: string) { }
  public campeonatos: Campeonato[];
  getCampeonatos(): Observable<Campeonato[]> {
    return this.http.get(this.url+"api/campeonato", "").map(response => response.json());



  }


  getResultadoJuego(idEquipo: number, idJuego: number): Observable<Resultado> {
    return this.http.get(this.url + "api/resultado/" + idJuego + "/" + idEquipo).map(response => response.json());



  }
  getEquipo(idEquipo: number): Observable<Equipo> {
    console.log(this.url + "api/resultado/equipo/" + idEquipo)
    return this.http.get(this.url + "api/resultado/equipo/" + idEquipo).map(response => response.json());



  }




  public getJuegos(idCampeonato: number): Observable<Juego[]> {

   return  this.http.get(this.url + 'api/Juego/' + idCampeonato).map(response => response.json());


  }

  public getResultado(idCampeonato: number): Observable<Juego[]> {

    return this.http.get(this.url + 'api/Juego/' + idCampeonato).map(response => response.json());


  }
  private extractData(res: Response) {
    let body = res.json();
    return body.fields || {};
  }
  guardarSancion(sancion: SancionColectiva): Observable<SancionColectiva> {
    let body = sancion;
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.post(this.url + 'api/sancion/', body, options).map(this.extractData);




  }

}



