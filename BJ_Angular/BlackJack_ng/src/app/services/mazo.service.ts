import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Carta } from '../Interfaces/carta';
import { CartaJugada } from '../Interfaces/carta-jugada';

@Injectable({
  providedIn: 'root'
})
export class MazoService {
  apiUrl: string = environment.urlApiBase;

  constructor(private http: HttpClient) {
  }

  getMazo(): Observable<any> {
    return this.http.get<any>(this.apiUrl + 'juego/mazo');
  }

  getCartaId(id: number): Observable<Carta> {
    return this.http.get<Carta>(this.apiUrl + 'mazo/getCartaxId/' + id)
  }

  /*postCarta(carta: Carta): Observable<any> {
    return this.http.post<CartaJugada>(this.apiUrl + 'cartaJugada/post', carta)
  }*/

  postCartaJugada(idJug: number, idPart: number, idCarta: number, jugador: string): Observable<CartaJugada> {
    const cmd = {
      "idCarta": idCarta,
      "idPartida": idPart,
      "jugador": jugador
    };
    const url = this.apiUrl + `cartaJugada/post/${idPart}+${idJug}`;
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(cmd);

    return this.http.post<CartaJugada>(url, body, { 'headers': headers });
  }
}
