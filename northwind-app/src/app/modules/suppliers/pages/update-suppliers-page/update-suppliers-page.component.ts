import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';

import { Supplier } from '../../models/Supplier';
import { SuppliersService } from '../../services/suppliers.service';

@Component({
  selector: 'app-update-suppliers-page',
  templateUrl: './update-suppliers-page.component.html',
  styleUrls: ['./update-suppliers-page.component.css']
})
export class UpdateSuppliersPageComponent implements OnInit {

  formSuppliers: FormGroup = this.formBuilder.group({
    id: null,
    companyName: [
      '',
      [Validators.required, Validators.minLength(3)]
    ],
    contactName: [
      '',
      [Validators.required, Validators.minLength(3)]
    ],
    contactTitle: [''],
    address: [''],
    city: [''],
    country: ['']
  });

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private suppliersService: SuppliersService
  ) { }

  ngOnInit(): void {
    if (!parseInt(this.route.snapshot.paramMap.get('id')!)) {
      this.router.navigate(['/error/not-found']);
      return;
    }
    
    const id: number = parseInt(this.route.snapshot.paramMap.get('id')!);

    this.suppliersService.getById(id).subscribe({
      next: (supplierResponse: Supplier) => {
        this.formSuppliers.setValue(supplierResponse);
      },
      error: error => {
        (error.status == 404)
          ? this.router.navigate(['/error/not-found'])
          : this.router.navigate(['/error']);
      }
    });
  }

  updateSupplier(supplier: Supplier): void {
    this.suppliersService.update(supplier).subscribe({
      next: () => {
        Swal.fire({
          title: '¡Éxito!',
          text: 'El proveedor se ha actualizado correctamente',
          icon: 'success',
          confirmButtonColor: '#22c55e'
        });
        
        this.router.navigate(['/suppliers']);
      },
      error: () => {
        Swal.fire({
          title: '¡Error!',
          text: 'No se pudo actualizar el proveedor, inténtelo más tarde.',
          icon: 'error',
          confirmButtonColor: '#22c55e'
        });
      }
    });
  }
}
