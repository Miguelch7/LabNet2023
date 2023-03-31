import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/Category';

@Component({
  selector: 'app-add-categories-page',
  templateUrl: './add-categories-page.component.html',
  styleUrls: ['./add-categories-page.component.css']
})
export class AddCategoriesPageComponent implements OnInit {

  constructor() { }

  category: Category = {
    categoryName: '',
    description: ''
  };

  ngOnInit(): void {
  }

  AddCategory(category: Category): void {
    this.category = category;
    console.log('Recibiendo...', this.category);
  }
}
