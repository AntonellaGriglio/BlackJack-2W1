import { Component, Input, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { MazoService } from 'src/app/services/mazo.service';

@Component({
  selector: 'app-carta',
  templateUrl: './carta.component.html',
  styleUrls: ['./carta.component.css']
})
export class CartaComponent implements OnInit {
  @Input() urlCarta: string = '';

  constructor(private mazoServ: MazoService, private route: Router) { }

  ngOnInit(): void {
  }

  
}
