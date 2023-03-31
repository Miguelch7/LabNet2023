import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { HomePageComponent } from './pages/home-page/home-page.component';
import { SectionItemComponent } from './components/section-item/section-item.component';

@NgModule({
  declarations: [
    HomePageComponent,
    SectionItemComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    HomePageComponent
  ]
})
export class HomeModule { }
