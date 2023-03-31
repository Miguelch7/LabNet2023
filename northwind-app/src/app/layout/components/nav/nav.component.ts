import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  northwindLogoUrl: string = '../../../../assets/images/northwind-logo.png';
  showMobileMenu: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  toggleMobileMenu(): void {
    this.showMobileMenu = !this.showMobileMenu;
  }
}
