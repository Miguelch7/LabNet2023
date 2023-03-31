import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { CategoriesRoutingModule } from './categories-routing.module';
import { CategoriesPageComponent } from './pages/categories-page/categories-page.component';
import { CategoriesTableComponent } from './components/categories-table/categories-table.component';
import { AddCategoriesPageComponent } from './pages/add-categories-page/add-categories-page.component';
import { CategoriesFormComponent } from './components/categories-form/categories-form.component';
import { UpdateCategoriesPageComponent } from './pages/update-categories-page/update-categories-page.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    CategoriesPageComponent,
    CategoriesTableComponent,
    AddCategoriesPageComponent,
    CategoriesFormComponent,
    UpdateCategoriesPageComponent
  ],
  imports: [
    CommonModule,
    CategoriesRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ]
})
export class CategoriesModule { }
