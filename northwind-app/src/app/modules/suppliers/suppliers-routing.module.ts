import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SuppliersPageComponent } from './pages/suppliers-page/suppliers-page.component';
import { AddSuppliersPageComponent } from './pages/add-suppliers-page/add-suppliers-page.component';
import { UpdateSuppliersPageComponent } from './pages/update-suppliers-page/update-suppliers-page.component';
import { DetailsSuppliersPageComponent } from './pages/details-suppliers-page/details-suppliers-page.component';

const routes: Routes = [
  {
    path: '',
    component: SuppliersPageComponent
  },
  {
    path: 'add',
    component: AddSuppliersPageComponent
  },
  {
    path: 'details/:id',
    component: DetailsSuppliersPageComponent
  },
  {
    path: 'update/:id',
    component: UpdateSuppliersPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SuppliersRoutingModule { }
