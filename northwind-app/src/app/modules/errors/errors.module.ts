import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { ErrorPageComponent } from './pages/error-page/error-page.component';



@NgModule({
  declarations: [
    ErrorPageComponent,
    NotFoundPageComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class ErrorsModule { }
