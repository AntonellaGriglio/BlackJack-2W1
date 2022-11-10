import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { JugadaService } from 'src/app/services/jugada.service';
import { MazoService } from 'src/app/services/mazo.service';

@Component({
  selector: 'app-botones',
  templateUrl: './botones.component.html',
  styleUrls: ['./botones.component.css']
})
export class BotonesComponent implements OnInit {
  @Input() resultado: string = '';
  @Input() idUsuario: number = 0;
  @Input() idPart:number;
  @Input() idJugada:number;
  @Input() puntosCrupier:number;
  @Input() puntosJugador:number;
  @Output() onQuedar = new EventEmitter();
  @Output() OnPedir = new EventEmitter();
  @Output() onProxRonda = new EventEmitter();
  @Output() onFinalizar = new EventEmitter();

  constructor(private carServ: MazoService, private route: Router, private jugServ:JugadaService) {
  }

  ngOnInit(): void {

  }

  pedir() {
    this.OnPedir.emit();
  }

  quedar() {
    this.onQuedar.emit();
  }

  proxRonda() {
    this.onProxRonda.emit();
  }

  finalizar() {
    this.onFinalizar.emit();
  }

  salir() {
    this.jugServ.actualizarPartida(this.idPart, this.idJugada, this.idUsuario, this.puntosCrupier,
      this.puntosJugador, 0, this.resultado).subscribe({
        next: () => {
          
        },
        error: (err) => {
          console.log("Error", err);
        }
      })
    

    this.route.navigate(['/principal/' + this.idUsuario]);
  }
}
