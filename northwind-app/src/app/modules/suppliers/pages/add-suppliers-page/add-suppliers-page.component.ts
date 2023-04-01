import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SuppliersService } from '../../services/suppliers.service';
import { Supplier } from '../../models/Supplier';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-suppliers-page',
  templateUrl: './add-suppliers-page.component.html',
  styleUrls: ['./add-suppliers-page.component.css']
})
export class AddSuppliersPageComponent implements OnInit {

  constructor(
    private router: Router,
    private suppliersService: SuppliersService
  ) { }

  ngOnInit(): void { }

  addSupplier(supplier: Supplier): void {
    this.suppliersService.add(supplier).subscribe({
      next: () => {
        Swal.fire({
          title: '¡Éxito!',
          text: 'El proveedor se ha creado correctamente',
          icon: 'success',
          confirmButtonColor: '#22c55e'
        });

        this.router.navigate(['/suppliers']);
      },
      error: () => {
        Swal.fire({
          title: '¡Error!',
          text: 'No se pudo crear el proveedor, inténtelo más tarde.',
          icon: 'error',
          confirmButtonColor: '#22c55e'
        });
      }
    });
  }
}
