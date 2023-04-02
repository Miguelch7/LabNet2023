import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SuppliersService } from '../../services/suppliers.service';
import { Supplier } from '../../models/Supplier';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-details-suppliers-page',
  templateUrl: './details-suppliers-page.component.html',
  styleUrls: ['./details-suppliers-page.component.css']
})
export class DetailsSuppliersPageComponent implements OnInit {

  supplier: Supplier = {
    id: 0,
    companyName: '',
    contactName: '',
    contactTitle: '',
    address: '',
    city: '',
    country: ''
  }

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private suppliersService: SuppliersService
  ) { }

  ngOnInit(): void {
    if (!parseInt(this.route.snapshot.paramMap.get('id')!)) {
      this.router.navigate(['error/not-found']);
      return;
    }

    const id: number = parseInt(this.route.snapshot.paramMap.get('id')!);

    this.suppliersService.getById(id).subscribe({
      next: (supplierResponse: Supplier) => {
        this.supplier = supplierResponse;
      },
      error: error => {
        (error.status == 404)
          ? this.router.navigate(['/error/not-found'])
          : this.router.navigate(['/error']);
      }
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
    .then((result) => {
      if (result.isConfirmed) {
        this.suppliersService.delete(id).subscribe({
          next: () => {
            Swal.fire({
              title: '¡Eliminado!',
              text: 'El proveedor se ha eliminado correctamente',
              icon: 'success',
              confirmButtonColor: '#22c55e'
            });

            this.router.navigate(['/suppliers']);
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
