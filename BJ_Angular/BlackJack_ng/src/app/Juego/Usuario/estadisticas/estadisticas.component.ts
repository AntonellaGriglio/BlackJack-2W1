import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ChartData } from 'chart.js';
import { Subscription } from 'rxjs';
import { filter} from 'rxjs/operators'
import { Carta } from 'src/app/Interfaces/carta';
import { CartaJugada } from 'src/app/Interfaces/carta-jugada';
import { Jugada } from 'src/app/Interfaces/jugada';
import { Partida } from 'src/app/Interfaces/partida';
import { Usuario } from 'src/app/Interfaces/usuario';
import { EstadisticasService } from 'src/app/services/estadisticas.service';


@Component({
  selector: 'app-estadisticas',
  templateUrl: './estadisticas.component.html',
  styleUrls: ['./estadisticas.component.css']
})
export class EstadisticasComponent implements OnInit , OnDestroy{
  idUsuario: number = 0;
  leyendasPartidas: string[]=["Ganadas","Perdidas","Empatadas"];
  leyendasCartas:string[]=['AC', 'AP', 'AD','AT','2C','2P','2D','2T','3C','3P','3D','3T','4C','4P','4D','4T',
    '5C','5P','5D','5T','6C','6P','6D','6T','7C','7P','7D','7T','8C','8P','8D','8T','9C','9P','9D','9T',
    '10C','10P','10D','10T','JC','JP','JD','JT','QC','QP','QD','QT','KC','KP','KD','KT'];
  partidas : ChartData<'pie'>;
  cartaJugadas: ChartData<'bar'>;
  usuario:ChartData<'pie'>;
  respuestaPar:Partida[];
  private subscription = new Subscription();
  


  constructor(private route: Router, private router: ActivatedRoute, private estaServ: EstadisticasService) { 
    this.idUsuario = this.router.snapshot.params["idUsu"];
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe;
  }

  ngOnInit(): void {
  this.cargaPartidas();
  this.cargarCartas();
  this.cargarUsuario();
   
    


  }
  cargarCartas() {
    this.subscription.add(
      this.estaServ.getCartasJugadas().subscribe({
        next: (respuesta)=>{
          console.log(respuesta);
          var listaCartaJugadas: CartaJugada[]= respuesta.listaCartaJugadas;
          this.cartaJugadas = {
            labels:this.leyendasCartas,
            datasets:[
              {
                  data:[
                    listaCartaJugadas.filter((a)=> a.idCarta === 1).length,
                    listaCartaJugadas.filter((a)=> a.idCarta === 2).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 3).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 4).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 5).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 6).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 7).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 8).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 9).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 10).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 11).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 12).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 13).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 14).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 15).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 16).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 17).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 18).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 19).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 20).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 21).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 22).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 23).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 24).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 25).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 26).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 27).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 28).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 29).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 30).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 31).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 32).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 33).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 34).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 35).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 36).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 37).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 38).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 39).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 40).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 41).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 42).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 43).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 44).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 45).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 46).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 47).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 48).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 49).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 50).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 51).length,
                  listaCartaJugadas.filter((a)=> a.idCarta === 52).length]
              },

            ]
          }
          
        }
      })
    )
    
  }
  cargaPartidas() {
    this.subscription.add(
      this.estaServ.getPartidas(this.idUsuario).subscribe({
        next: (respuesta)=> {
          console.log(respuesta)
          var listaPartida: Partida[]= respuesta.listaPartida;
          this.respuestaPar = respuesta;
          this.partidas = {
            labels:this.leyendasPartidas,
            datasets:[
              {
                data:[listaPartida.filter((p) => p.resultado === 'Ganaste!').length,
                listaPartida.filter((p) => p.resultado === 'Perdiste').length,
                listaPartida.filter((p) => p.resultado === 'Empate').length],
                
              }
            ]
          }
        },
        error: () => alert("Error en la barra")
        
      })
     
    )
  }
  cargarUsuario(){
    this.subscription.add(
      this.estaServ.getPartidasGanadas().subscribe({
        next:(respuesta) =>{
          var listaUsuarios: Usuario[] = respuesta.listaUsuarios;
          this.usuario={
            labels: ["Cristobal", "Antonella", "hola", "Roberto"],
            datasets:[
              {
              data:[listaUsuarios.filter((u) => u.idUsuario === 1).length,
                listaUsuarios.filter((u) => u.idUsuario === 2).length,
                listaUsuarios.filter((u) => u.idUsuario === 3).length,
                listaUsuarios.filter((u) => u.idUsuario === 4).length]
              }
            ]
          }
          console.log(respuesta)
        }
      })
    )

  }
  salir() {

    this.route.navigate(['/principal/' + this.idUsuario]);
  }

}
