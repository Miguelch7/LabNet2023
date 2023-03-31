import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/Category';

@Component({
  selector: 'app-update-categories-page',
  templateUrl: './update-categories-page.component.html',
  styleUrls: ['./update-categories-page.component.css']
})
export class UpdateCategoriesPageComponent implements OnInit {

  category: Category = {
    categoryName: '',
    description: ''
  };

  constructor() { }

  ngOnInit(): void {
  }

  UpdateCategory(category: Category): void {
    this.category = category;
    console.log('Recibiendo...', this.category);
  }

}
