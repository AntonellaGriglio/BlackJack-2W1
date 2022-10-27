import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Jugada } from 'src/app/Interfaces/jugada';
import { Partida } from 'src/app/Interfaces/partida';
import { Usuario } from 'src/app/Interfaces/usuario';
import { JugadaService } from 'src/app/services/jugada.service';

@Component({
  selector: 'app-partidas',
  templateUrl: './partidas.component.html',
  styleUrls: ['./partidas.component.css']
})
export class PartidasComponent implements OnInit {
  idUsuario: number = 0;
  usuario = {} as Usuario;
  jugada = {} as Jugada;
  listaPartidas: Jugada[] = [];
  idPartida: number = 0;

  constructor(private route: Router, private router: ActivatedRoute, private jugServ: JugadaService) {
    this.idUsuario = this.router.snapshot.params["idUsu"];
    this.cargarLista();
  }

  ngOnInit(): void {
  }

  continuar(idJugada: number) {
    this.jugServ.getPartida(idJugada, this.idUsuario).subscribe({
      next: (p: any) => {
        console.log("partida:",p);
        this.idPartida = p.idJugada;
        this.route.navigate([`juego/${idJugada}/${this.idUsuario}/${this.idPartida}`]);
      },
      error: (err) => {
        console.log("Error",err);
      }
    });
  }

  async cargarLista() {
    this.jugServ.getJugadas(this.idUsuario).subscribe({
      next: async (part: any) => {
        console.log(part);
        this.listaPartidas = part.listaJugadas;
      },
      error: (err) => {
        console.log("Error",err);
      }
    })
  }
}
