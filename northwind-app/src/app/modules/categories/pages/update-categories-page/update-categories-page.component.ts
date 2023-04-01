import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';

import { Category } from '../../models/Category';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-update-categories-page',
  templateUrl: './update-categories-page.component.html',
  styleUrls: ['./update-categories-page.component.css']
})
export class UpdateCategoriesPageComponent implements OnInit {

  formCategories: FormGroup = this.formBuilder.group({
    id: null,
    categoryName: [
      '', 
      [Validators.required, Validators.minLength(3)]
    ],
    description: ['']
  });

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private categoriesService: CategoriesService
  ) { }

  ngOnInit(): void {
    if (parseInt(this.route.snapshot.paramMap.get('id')!)) {
      const id: number = parseInt(this.route.snapshot.paramMap.get('id')!);

      this.categoriesService.getById(id).subscribe((categoryResponse: Category) => {
        this.formCategories.setValue(categoryResponse);
      });
    };
  }

  updateCategory(category: Category): void {
    this.categoriesService.update(category).subscribe(res => {
      Swal.fire({
        title: '¡Éxito!',
        text: 'La categoría se ha actualizado correctamente',
        icon: 'success',
        confirmButtonColor: '#22c55e'
      });
      
      this.router.navigate(['/categories']);
    });
  }
}
