import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoriesRoutingModule } from './categories-routing.module';
import { CategoriesPageComponent } from './pages/categories-page/categories-page.component';
import { CategoriesTableComponent } from './components/categories-table/categories-table.component';


@NgModule({
  declarations: [
    CategoriesPageComponent,
    CategoriesTableComponent
  ],
  imports: [
    CommonModule,
    CategoriesRoutingModule
  ]
})
export class CategoriesModule { }
