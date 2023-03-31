import { Component, OnInit } from '@angular/core';
import { CategoriesModel } from '../../models/CategoriesModel';

@Component({
  selector: 'app-update-categories-page',
  templateUrl: './update-categories-page.component.html',
  styleUrls: ['./update-categories-page.component.css']
})
export class UpdateCategoriesPageComponent implements OnInit {

  category: CategoriesModel = {
    categoryName: '',
    description: ''
  };

  constructor() { }

  ngOnInit(): void {
  }

  UpdateCategory(category: CategoriesModel): void {
    this.category = category;
    console.log('Recibiendo...', this.category);
  }

}
