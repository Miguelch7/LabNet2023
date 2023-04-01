import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SuppliersRoutingModule } from './suppliers-routing.module';
import { SuppliersPageComponent } from './pages/suppliers-page/suppliers-page.component';
import { SuppliersTableComponent } from './components/suppliers-table/suppliers-table.component';


@NgModule({
  declarations: [
    SuppliersPageComponent,
    SuppliersTableComponent
  ],
  imports: [
    CommonModule,
    SuppliersRoutingModule
  ]
})
export class SuppliersModule { }
