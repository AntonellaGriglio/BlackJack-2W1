import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JuegoComponent } from './Juego/juego/juego.component';
import { CrearComponent } from './Juego/Usuario/crear/crear.component';
import { EstadisticasComponent } from './Juego/Usuario/estadisticas/estadisticas.component';
import { LoginComponent } from './Juego/Usuario/login/login.component';
import { PartidasComponent } from './Juego/Usuario/partidas/partidas.component';
import { PrincipalComponent } from './Juego/Usuario/principal/principal.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'alta', component: CrearComponent },
  { path: 'principal/:id', component: PrincipalComponent },
  { path: 'juego/:id/:idU/:idP', component: JuegoComponent },
  { path: 'lista/:idUsu', component: PartidasComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'estadisticas/:idUsu', component: EstadisticasComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
