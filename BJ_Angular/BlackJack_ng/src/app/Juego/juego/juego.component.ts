import { Component, OnInit } from '@angular/core';
import { waitForAsync } from '@angular/core/testing';
import { ActivatedRoute, Route, Router, RouterPreloader } from '@angular/router';
import { Subscription } from 'rxjs';
import { Carta } from 'src/app/Interfaces/carta';
import { CartaJugada } from 'src/app/Interfaces/carta-jugada';
import { Jugada } from 'src/app/Interfaces/jugada';
import { Partida } from 'src/app/Interfaces/partida';
import { Usuario } from 'src/app/Interfaces/usuario';
import { JugadaService } from 'src/app/services/jugada.service';
import { MazoService } from 'src/app/services/mazo.service';

@Component({
  selector: 'app-juego',
  templateUrl: './juego.component.html',
  styleUrls: ['./juego.component.css']
})
export class JuegoComponent implements OnInit {
  subs = new Subscription();
  puntosCrupier: number = 0;
  puntosJugador: number = 0;
  idPart: number = 0;

  resultado: string = '';

  cartasCrupier: Carta[] = [];
  cartasJugador: Carta[] = [];

  cartasJugadas: Carta[] = [];
  cartaJ = {} as CartaJugada;
  disponibles: Carta[] = [];
  ases: Carta[] = [];
  mazo: Carta[] = [];

  usuario = {} as Usuario;
  idJugada: number = 0;
  idMazoJugado: number = 0;
  estado: number = 0;

  asChanged = false;

  jugador: string = '';
  cantidadCartas = 0;
 

  constructor(private carServ: MazoService, private jugServ: JugadaService, private router: ActivatedRoute,
    private route: Router) {
    this.idJugada = this.router.snapshot.params["id"];
    this.usuario.id = this.router.snapshot.params["idU"];
    this.idPart = this.router.snapshot.params["idP"];
    this.carServ.getMazo().subscribe((res) => {
      //console.log(res);
      //console.log("---");
      this.mazo = res.mazo as Carta[];
      this.cantidadCartas = this.mazo.length;
      this.ases = this.mazo.filter((element) => element.isAs === 1);
      this.disponibles = this.mazo;
    });

    this.jugServ.getPartida(this.idJugada, this.usuario.id).subscribe({
      next: (p: any) => {
        this.cartasJugador = p.cartasJugadas;
        this.puntosJugador = p.puntosJug;
        this.puntosCrupier = p.puntosCrup;
      }, error: (err) => {
        console.log("Error", err);
      }
    })
  }

  ngOnInit(): void {

  }

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  obtenerCarta(jugador: string) {
    let cartaR = this.disponibles.splice(Math.floor(Math.random() * this.cantidadCartas), 1)[0];
    console.log("carta:", cartaR);
    console.log("cartas:", this.disponibles);
    if (jugador === 'crupier') {
      this.cartasCrupier.push(cartaR);
      let valorCarta: number = this.obtenerPuntos(cartaR as Carta, this.jugador);

      this.puntosCrupier += valorCarta;
    } else {
      this.cartasJugador.push(cartaR);
      let valorCarta: number = this.obtenerPuntos(cartaR as Carta, this.jugador);
      this.puntosJugador += valorCarta;

      if (this.puntosJugador > 21) {
        console.log(this.puntosJugador);
        this.cartasJugador.forEach((e) => {
          if (this.ases.filter((item) => item.id == e.id).length > 0 && !this.asChanged) {
            this.asChanged = true;
            this.puntosJugador = this.puntosJugador - 10;
          }
        });
      }
    }
    this.cartasJugadas = this.cartasJugador.concat(this.cartasCrupier);
  }

  obtenerPuntos(carta: Carta, jugador: string) {
    let puntaje = 0;
    let valorCarta = 0;

    if (jugador === 'crupier') {
      puntaje = this.puntosCrupier;
    } else {
      puntaje = this.puntosJugador;
    }
    valorCarta = carta.valor;

    return valorCarta;
  }

  //PEDIR!!!
  puntosJug(jugador: string) {
    this.obtenerCarta(jugador);

    if (this.puntosJugador > 21) {
      this.resultado = 'Perdiste';
      //this.puntos();
    }

    this.puntosJugador = this.puntosJugador;

    //Llenar la carta jugada en API
    this.cartasJugadas.forEach(carta => {
      this.cartaJ.cartaJ = carta;
      this.cartaJ.jugador = jugador;
    })

      //antes de agregar esto lo hacia banca q ahi tiene q habilitar el proxima ronda y mostrar el resultad
      this.subs.add(this.carServ.postCartaJugada(this.idJugada, this.idPart, this.cartaJ.cartaJ.id, this.cartaJ.jugador).
        subscribe({
          next: (cj: CartaJugada) => {
            console.log(cj);
          },
          error: (err) => {
            console.log("Error", err);
          }
        }))
    
  };

  //QUEDAR!!!
  puntos() {
    while (this.puntosCrupier <= 17) {
      this.obtenerCarta('crupier');
      this.puntosCrupier = this.puntosCrupier;
    }

    if (this.puntosCrupier < 22 && this.puntosCrupier > this.puntosJugador) {
      this.resultado = 'Perdiste';
    } else if (this.puntosCrupier < 22 && this.puntosCrupier < this.puntosJugador) {
      this.resultado = 'Ganaste!';
    } else if (this.puntosCrupier < 22 && this.puntosCrupier === this.puntosJugador) {
      this.resultado = 'Empate';
    } else if (this.puntosCrupier > 21 && this.puntosJugador < 22) {
      this.resultado = 'Ganaste!';
    }

    this.guardarPartida();
  }

  //Actualizar partida
  guardarPartida() {
    this.jugServ.actualizarPartida(this.idPart, this.idJugada, this.usuario.id, this.puntosCrupier,
      this.puntosJugador, 0, this.resultado).subscribe({
        next: () => {
          alert("Guardado correctamente");
        },
        error: (err) => {
          console.log("Error", err);
        }
      })
  }

  //Finalizar jugada
  finalizarJugada() {
    this.subs.add(this.jugServ.finalizarJugada(this.idJugada, this.usuario.id).subscribe({
      next: () => {
        alert("Partida finalizada");
        this.route.navigate(['principal/' + this.usuario.id]);
      },
      error: (err) => {
        console.log("Error", err);
      }
    }))
  }

  limpiar() {
    this.jugServ.nuevaPartida(this.usuario.id, this.idJugada).subscribe({
      next: (part: Partida) => {
        var idPartida = part.idPartida;
        this.route.navigate(['juego/' + this.idJugada + '/' + this.usuario.id + '/' + idPartida]).then(() => {
          window.location.reload();
        });
      }
    });
  }
}
