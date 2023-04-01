import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';

import { Supplier } from '../../models/Supplier';
import { SuppliersService } from '../../services/suppliers.service';

@Component({
  selector: 'app-suppliers-table',
  templateUrl: './suppliers-table.component.html',
  styleUrls: ['./suppliers-table.component.css']
})
export class SuppliersTableComponent implements OnInit {

  suppliersList: Array<Supplier> = [];

  constructor(
    private suppliersService: SuppliersService
  ) { }

  ngOnInit(): void {
    this.suppliersService.getAll().subscribe((suppliers: Supplier[]) => {
      this.suppliersList = suppliers;
    });
  }

  onDelete(id: number) {
    Swal.fire({
      title: '¿Estás seguro que deseas eliminar el proveedor?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#22c55e',
      cancelButtonColor: '#dc2626',
      confirmButtonText: 'Si, eliminar!',
      cancelButtonText: 'Cancelar'
    })
    .then(result => {
      if (result.isConfirmed) {
        this.suppliersService.delete(id).subscribe({
          next: () => {
            Swal.fire({
              title: '¡Eliminado!',
              text: 'El proveedor se ha eliminado correctamente',
              icon: 'success',
              confirmButtonColor: '#22c55e'
            });

            this.suppliersList = this.suppliersList.filter(s => s.id != id);
          },
          error: () => {
            Swal.fire({
              title: '¡Error!',
              text: 'No se pudo eliminar el proveedor, inténtelo más tarde.',
              icon: 'error',
              confirmButtonColor: '#22c55e'
            });
          }
        });
      }
    });
  }
}
