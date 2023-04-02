import { Component } from '@angular/core';
import { Section } from './core/models/Section';
import sections from 'src/app/data/sections';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  sectionsList: Array<Section> = [];
  
  constructor() { }

  ngOnInit(): void {
    this.sectionsList = sections;
  }
  
}
