import { Component, OnInit } from '@angular/core';
import { Section } from '../../../../core/models/Section';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  sectionsList: Array<Section> = [];

  constructor() { }

  ngOnInit(): void {
    this.sectionsList = [
      {
        name: 'Categorías',
        text: 'Cree, liste, edite y elimine todas las categorías de Northwind.',
        icon: 'category',
        router: ['/', 'categories']
      },
      {
        name: 'Proveedores',
        text: 'Cree, liste, edite y elimine todos los proveedores de Northwind.',
        icon: 'groups',
        router: ['/', 'suppliers']
      }
    ]
  }

}
