import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http'
import { Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';

import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { DatePipe } from '@angular/common';
import { Campeonato } from '../Domain/Campeonato.model';
import { Juego } from '../Domain/juego.model';

@Injectable()
export class juegoService {
  private url = 'https://localhost:44396/';
  private juegos: Juego[] = new Array<Juego>();
  public juego: Juego = new Juego();


  constructor(private http: Http, public htp: HttpClient, @Inject('BASE_URL') public baseUrl: string) {

  }

  buscarJuego(identificador: number): Observable<Juego> {

    return this.http.get(this.url + "api/juego/" + identificador).map(response => response.json());

  }

  actualizarJuego(juego: Juego): Observable<Juego> {
    return this.http.put(this.url + 'api/jugador/' + juego.identificador, juego).map(response => response.json());

  }

  actualizar(juego: Juego): Observable<Juego>{
    console.log(juego.estadoJuego + "  --1");
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.put(this.url + 'api/juego/', juego, options).map(this.extractData);

  }

  agregarCampeonato(campeonato: Campeonato): Observable<Campeonato> {
    console.log(campeonato.categoria + "  --1");
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.post(this.url + 'api/campeonato/', campeonato, options).map(this.extractData);

  }

  private extractData(res: Response) {
    let body = res.json();
    return body.fields || {};
  }


}
