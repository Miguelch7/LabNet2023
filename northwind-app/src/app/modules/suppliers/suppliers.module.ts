import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { SuppliersRoutingModule } from './suppliers-routing.module';
import { SuppliersPageComponent } from './pages/suppliers-page/suppliers-page.component';
import { SuppliersTableComponent } from './components/suppliers-table/suppliers-table.component';
import { SuppliersFormComponent } from './components/suppliers-form/suppliers-form.component';
import { AddSuppliersPageComponent } from './pages/add-suppliers-page/add-suppliers-page.component';
import { UpdateSuppliersPageComponent } from './pages/update-suppliers-page/update-suppliers-page.component';


@NgModule({
  declarations: [
    SuppliersPageComponent,
    SuppliersTableComponent,
    AddSuppliersPageComponent,
    SuppliersFormComponent,
    UpdateSuppliersPageComponent,
  ],
  imports: [
    CommonModule,
    SuppliersRoutingModule,
    ReactiveFormsModule
  ]
})
export class SuppliersModule { }
