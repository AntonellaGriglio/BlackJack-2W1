import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioLogin } from 'src/app/Interfaces/usuario-login';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  usuario = {} as UsuarioLogin;

  constructor(private route: Router, private userServ: UsuarioService) { }

  ngOnInit(): void {
  }

  iniciarSesion() {
    this.userServ.postLogin(this.usuario.nombreUsuario, this.usuario.password).subscribe((data) => {
      if (data.ok) {
        console.log(data);
        //this.userServ.setToken(data.token);
        this.route.navigate(['/principal/' + data.id]);
      } else {
        alert(data.error);
      }
    })
  }

  Registrar() {
    this.route.navigate(['/alta']);
  }
}
