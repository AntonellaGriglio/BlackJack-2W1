import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UsuarioLogin } from '../Interfaces/usuario-login';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  apiUrl: string = environment.urlApiBase;

  constructor(private http: HttpClient, private cookies: CookieService) {
  }

  postLogin(nombreUsu: string, pass: string): Observable<any> {
    const cmd = {
      "usuario": nombreUsu,
      "password": pass
    };
    const url = this.apiUrl + 'user/login';
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(cmd);

    return this.http.post(url, body, { 'headers': headers });
  }

  altaUsuario(usuario: string, pass: string): Observable<UsuarioLogin> {
    const cmd = {
      "usuario": usuario,
      "password": pass
    };
    const url = this.apiUrl + 'user/crear';
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(cmd);

    return this.http.post<UsuarioLogin>(url, body, { 'headers': headers });
  }

  getUserId(id: number): Observable<any> {
    const url = this.apiUrl + `user/getById/${id}`;
    const headers = { 'content-type': 'application/json' }

    return this.http.get(url, { 'headers': headers });
  }

  /*

  setToken(token: string) {
    this.cookies.set("token", token);
  }

  getToken() {
    return this.cookies.get("token");
  }
  getUser() {
    return this.http.get();
  }

  getUserLogged() {
    const token = this.getToken();
    // Aquí iría el endpoint para devolver el usuario para un token
  }*/
}
