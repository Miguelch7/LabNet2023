import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './modules/home/pages/home-page/home-page.component';

const routes: Routes = [
  {
    path: '',
    component: HomePageComponent
  },
  {
    path: 'categories',
    loadChildren: () => import('./modules/categories/categories-routing.module').then(m => m.CategoriesRoutingModule)
  },
  {
    path: 'error',
    loadChildren: () => import('./modules/errors/errors-routing.module').then(m => m.ErrorsRoutingModule)
  },
  {
    path: '**',
    redirectTo: '/error/not-found'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
