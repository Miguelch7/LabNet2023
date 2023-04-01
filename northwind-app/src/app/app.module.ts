import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutModule } from './layout/layout.module';
import { HomeModule } from './modules/home/home.module';
import { CategoriesModule } from './modules/categories/categories.module';
import { ErrorsModule } from './modules/errors/errors.module';
import { SuppliersModule } from './modules/suppliers/suppliers.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    LayoutModule,
    HomeModule,
    CategoriesModule,
    SuppliersModule,
    ErrorsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
