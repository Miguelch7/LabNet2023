import { Component, Input, OnInit } from '@angular/core';
import { Section } from 'src/app/core/models/Section';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  northwindLogoUrl: string = '../../../../assets/images/northwind-logo.png';
  showMobileMenu: boolean = false;
  @Input() sectionsList: Array<Section> = [];

  constructor() { }

  ngOnInit(): void {
  }

  toggleMobileMenu(): void {
    this.showMobileMenu = !this.showMobileMenu;
  }
}
