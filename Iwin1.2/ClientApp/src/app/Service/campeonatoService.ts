import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http'
import { Response } from '@angular/http';

import { Observable } from "rxjs/Observable";
import "rxjs/add/operator/map";
import { DatePipe } from '@angular/common';
import { Campeonato } from '../Domain/Campeonato.model';

@Injectable()
export class campeonatoService {
  private url = 'https://localhost:44396/';
  constructor(private http: Http) {

  }


  agregarCampeonato(campeonato: Campeonato): Observable<Campeonato> {
    console.log(campeonato.categoria+"  --1");
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.post(this.url + 'api/campeonato/', campeonato, options).map(this.extractData);

  }

  private extractData(res: Response) {
    let body = res.json();
    return body.fields || {};
  }


}
