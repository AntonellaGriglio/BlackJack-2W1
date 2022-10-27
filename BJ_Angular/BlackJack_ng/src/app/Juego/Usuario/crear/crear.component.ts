import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UsuarioLogin } from 'src/app/Interfaces/usuario-login';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-crear',
  templateUrl: './crear.component.html',
  styleUrls: ['./crear.component.css']
})
export class CrearComponent implements OnInit {
  usuario = {} as UsuarioLogin;
  private subs = new Subscription();

  constructor(private route: Router, private userServ: UsuarioService) { }

  ngOnInit(): void {
  }

  registrar() {
    this.subs.add(
      this.userServ.altaUsuario(this.usuario.nombreUsuario, this.usuario.password).subscribe({
        next: (nuevo: UsuarioLogin) => {
          this.route.navigate(['/principal/' + nuevo.id]);
        }, error: (err) => {
          console.log("Error",err);
        }
      })
    )
  }

  Cancelar() {
    this.route.navigate(['']);
  }

}
