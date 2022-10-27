import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Jugada } from '../Interfaces/jugada';
import { Partida } from '../Interfaces/partida';

@Injectable({
  providedIn: 'root'
})
export class JugadaService {
  apiUrl: string = environment.urlApiBase;

  constructor(private http: HttpClient) { }

  //------------PARTIDAS---------------
  //Nueva Partida
  nuevaPartida(idUsuario: number, idJugada: number): Observable<any> {
    const url = this.apiUrl + `partida/nueva/${idUsuario}+${idJugada}`;
    const headers = { 'content-type': 'application/json' }

    return this.http.post(url, null, { 'headers': headers });
  }

  //"Quedar"
  actualizarPartida(idPart: number, idJug: number, idUsu: number, puntosCrupier: number, puntosJugador: number,
    estado:number, resultado: string): Observable<any> {
    const cmd = {
      "idJugada": idJug,
      "puntosCrup": puntosCrupier,
      "puntosJug": puntosJugador,
      "estado": estado,
      "resultado": resultado
    };
    const url = this.apiUrl + `partida/actualizar/${idUsu}+${idPart}+${idJug}`;
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(cmd);

    return this.http.put(url, body, { 'headers': headers });
  }

  //"Continuar"
  getPartida(idJug: number, idUsu: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + `jugada/continuar/${idJug}+${idUsu}`);
  }

  getUltPartida(idJug: number, idUsu: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + `jugada/buscar/${idJug}+${idUsu}`);
  }

  //------------JUGADAS---------------
  //"Listado"  
  getJugadas(idUsuario: number): Observable<Jugada[]> {
    return this.http.get<Jugada[]>(this.apiUrl + "jugada/lista/" + idUsuario);
  }

  //"Nueva Jugada"
  nuevaJugada(idUsuario: number): Observable<any> {
    const cmd = {
      "idUsuario": idUsuario
    };
    const url = this.apiUrl + `jugada/nueva/${idUsuario}`;
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(cmd);

    return this.http.post(url, body, { 'headers': headers });
  }

  //"Finalizar Jugada"
  finalizarJugada(idJug: number, idUsu: number): Observable<any> {
    return this.http.put(this.apiUrl + `jugada/finalizar/${idJug}+${idUsu}`, null);
  }
}
