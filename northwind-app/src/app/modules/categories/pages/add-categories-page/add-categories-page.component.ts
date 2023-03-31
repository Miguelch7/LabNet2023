import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Category } from '../../models/Category';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-add-categories-page',
  templateUrl: './add-categories-page.component.html',
  styleUrls: ['./add-categories-page.component.css']
})
export class AddCategoriesPageComponent implements OnInit {

  constructor(
    private router: Router,
    private categoriesService: CategoriesService
  ) { }

  category: Category = {
    categoryName: '',
    description: ''
  };

  ngOnInit(): void {
  }

  addCategory(category: Category): void {
    this.category = category;
    
    this.categoriesService.add(category).subscribe(res => {
      this.router.navigate(['/categories']);
    });
  }
}
