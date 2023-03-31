import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/Category';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-categories-page',
  templateUrl: './categories-page.component.html',
  styleUrls: ['./categories-page.component.css']
})
export class CategoriesPageComponent implements OnInit {

  categoriesList: Category[] = [];

  constructor(
    private categoriesService: CategoriesService
  ) { }

  ngOnInit(): void {
    this.categoriesService.getAll().subscribe((categories: Category[]) => {
      this.categoriesList = categories;
    });
  }
}
