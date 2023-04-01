import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SuppliersPageComponent } from './pages/suppliers-page/suppliers-page.component';
import { AddSuppliersPageComponent } from './pages/add-suppliers-page/add-suppliers-page.component';

const routes: Routes = [
  {
    path: '',
    component: SuppliersPageComponent
  },
  {
    path: 'add',
    component: AddSuppliersPageComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SuppliersRoutingModule { }
