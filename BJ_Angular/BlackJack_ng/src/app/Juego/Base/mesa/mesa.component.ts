import { Component, Input, OnInit } from '@angular/core';
import { MazoService } from 'src/app/services/mazo.service';

@Component({
  selector: 'app-mesa',
  templateUrl: './mesa.component.html',
  styleUrls: ['./mesa.component.css']
})
export class MesaComponent implements OnInit {
  @Input() cartasCrupier: any[] = [];
  @Input() cartasJugador: any[] = [];
  @Input() puntosCrupier: number = 0;
  @Input() puntosJugador: number = 0;
  
  cartaUrl: string = './../../../../assets/cartas/'

  constructor(private carServ: MazoService) { }

  ngOnInit(): void {
  }

}
