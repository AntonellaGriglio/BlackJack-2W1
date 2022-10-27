import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CookieService } from 'ngx-cookie-service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MesaComponent } from './Juego/Base/mesa/mesa.component';
import { CartaComponent } from './Juego/Base/carta/carta.component';
import { BotonesComponent } from './Juego/Base/botones/botones.component';
import { LoginComponent } from './Juego/Usuario/login/login.component';
import { CrearComponent } from './Juego/Usuario/crear/crear.component';
import { PrincipalComponent } from './Juego/Usuario/principal/principal.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JuegoComponent } from './Juego/juego/juego.component';
import { UsuarioService } from './services/usuario.service';
import { MazoService } from './services/mazo.service';
import { PartidasComponent } from './Juego/Usuario/partidas/partidas.component';
import { JugadaService } from './services/jugada.service';

@NgModule({
  declarations: [
    AppComponent,
    MesaComponent,
    CartaComponent,
    BotonesComponent,
    LoginComponent,
    CrearComponent,
    PrincipalComponent,
    JuegoComponent,
    PartidasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [UsuarioService, CookieService, MazoService, JugadaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
