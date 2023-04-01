import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SuppliersPageComponent } from './pages/suppliers-page/suppliers-page.component';

const routes: Routes = [
  {
    path: '',
    component: SuppliersPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SuppliersRoutingModule { }
