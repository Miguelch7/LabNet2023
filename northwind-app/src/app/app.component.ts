import { Component } from '@angular/core';
import { Section } from './core/models/Section';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

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
