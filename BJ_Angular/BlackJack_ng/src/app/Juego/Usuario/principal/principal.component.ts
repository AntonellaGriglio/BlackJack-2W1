import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Jugada } from 'src/app/Interfaces/jugada';
import { Partida } from 'src/app/Interfaces/partida';
import { Usuario } from 'src/app/Interfaces/usuario';
import { JugadaService } from 'src/app/services/jugada.service';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css']
})
export class PrincipalComponent implements OnInit {
  private subs = new Subscription();
  idUsuario: number = 0;
  usuario = {} as Usuario;
  jugada = {} as Jugada;
  idPartida: number = 0;
  idJug:number=0;

  constructor(private route: Router, private jugServ: JugadaService, private router: ActivatedRoute,
    private userServ: UsuarioService) {
    this.idUsuario = this.router.snapshot.params["id"];

    this.getUser(this.idUsuario);
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  async getUser(id: number) {
    this.subs.add(this.userServ.getUserId(id).subscribe({
      next: (user: Usuario) => {
        this.usuario.id = user.id;
        this.usuario.usuario = user.usuario;
      },
      error: (err) => {
        console.log("Error",err);
      }
    }))
  }


  nuevaPartida() {
    console.log(this.usuario.id);

    this.subs.add(this.jugServ.nuevaJugada(this.usuario.id).subscribe({
      next: (jug: Jugada) => {
        this.idJug= jug.idJugada;
        this.jugada= jug;
        console.log(this.jugada.idJugada);
        this.jugServ.nuevaPartida(this.usuario.id, this.idJug).subscribe({
          next: (part: Partida) => {
            this.idPartida = part.idPartida;
            console.log(this.idJug);
            this.route.navigate(['juego/' + jug.idJugada + '/' + this.usuario.id + '/' + this.idPartida]);
          }
        })
      },
      error: (err) => {
        console.log("Error",err);
      }
    }))
  }

  listadoPartidas() {
    this.route.navigate(['/lista/' + this.idUsuario]);
  }
  estadisticas(){
    this.route.navigate(['/estadisticas/' + this.idUsuario]);
  }
}
