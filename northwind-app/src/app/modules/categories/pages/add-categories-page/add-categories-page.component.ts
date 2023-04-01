import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

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

  ngOnInit(): void { }

  addCategory(category: Category): void {
    this.categoriesService.add(category).subscribe(res => {
      Swal.fire({
        title: '¡Éxito!',
        text: 'La categoría se ha creado correctamente',
        icon: 'success',
        confirmButtonColor: '#22c55e'
      });
      
      this.router.navigate(['/categories']);
    }, error => {
      Swal.fire({
        title: '¡Error!',
        text: 'No se pudo crear la categoría, inténtelo más tarde.',
        icon: 'error',
        confirmButtonColor: '#22c55e'
      });
    });
  }
}
