import { Component, OnInit } from '@angular/core';
import { Section } from '../../../../core/models/Section';
import sections from 'src/app/data/sections';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  sectionsList: Array<Section> = [];

  constructor() { }

  ngOnInit(): void {
    this.sectionsList = sections;
  }

}
