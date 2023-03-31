import { Component, OnInit } from '@angular/core';
import { CategoriesModel } from '../../models/CategoriesModel';

@Component({
  selector: 'app-add-categories-page',
  templateUrl: './add-categories-page.component.html',
  styleUrls: ['./add-categories-page.component.css']
})
export class AddCategoriesPageComponent implements OnInit {

  constructor() { }

  category: CategoriesModel = {
    categoryName: '',
    description: ''
  };

  ngOnInit(): void {
  }

  AddCategory(category: CategoriesModel): void {
    this.category = category;
    console.log('Recibiendo...', this.category);
  }
}
