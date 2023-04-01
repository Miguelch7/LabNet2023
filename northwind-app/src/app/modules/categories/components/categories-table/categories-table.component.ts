import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';

import { Category } from '../../models/Category';
import { CategoriesService } from '../../services/categories.service';

@Component({
  selector: 'app-categories-table',
  templateUrl: './categories-table.component.html',
  styleUrls: ['./categories-table.component.css']
})
export class CategoriesTableComponent implements OnInit {

  categoriesList: Array<Category> = [];

  constructor(
    private categoriesService: CategoriesService
  ) { }

  ngOnInit(): void {
    this.categoriesService.getAll().subscribe((categories: Category[]) => {
      this.categoriesList = categories;
    });
  }

  onDelete(id: number) {
    Swal.fire({
      title: '¿Estás seguro que deseas eliminar la categoría?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#22c55e',
      cancelButtonColor: '#dc2626',
      confirmButtonText: 'Si, eliminar!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.categoriesService.delete(id).subscribe(res => {
          Swal.fire({
            title: '¡Eliminado!',
            text: 'La categoría se ha eliminado correctamente',
            icon: 'success',
            confirmButtonColor: '#22c55e'
          });

          this.categoriesList = this.categoriesList.filter(c => c.id != id);
        }, error => {
          Swal.fire({
            title: '¡Error!',
            text: 'No se pudo eliminar la categoría, inténtelo más tarde.',
            icon: 'error',
            confirmButtonColor: '#22c55e'
          });
        });
      }
    })
    
  }

}
