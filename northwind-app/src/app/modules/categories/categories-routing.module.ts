import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CategoriesPageComponent } from './pages/categories-page/categories-page.component';
import { AddCategoriesPageComponent } from './pages/add-categories-page/add-categories-page.component';
import { UpdateCategoriesPageComponent } from './pages/update-categories-page/update-categories-page.component';

const routes: Routes = [
  {
    path: '',
    component: CategoriesPageComponent
  },
  {
    path: 'add',
    component: AddCategoriesPageComponent
  },
  {
    path: 'update/:id',
    component: UpdateCategoriesPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesRoutingModule { }
