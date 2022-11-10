import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Partida } from '../Interfaces/partida';

@Injectable({
  providedIn: 'root'
})
export class EstadisticasService {
  apiUrl: string = environment.urlApiBase

  constructor(private http : HttpClient) { }

  getPartidas(idUsu:number): Observable<any>{
    return this.http.get<any>(this.apiUrl+'partidas/lista/'+ idUsu)
  }
  
  getCartasJugadas(): Observable<any>{
    return this.http.get(this.apiUrl+'cartasJugadas/lista')
  }
  getPartidasGanadas(): Observable<any>{
    return this.http.get(this.apiUrl + 'partidas/lista/ganadas')
  }

}
