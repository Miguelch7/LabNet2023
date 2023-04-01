import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Supplier } from '../../models/Supplier';

@Component({
  selector: 'app-suppliers-form',
  templateUrl: './suppliers-form.component.html',
  styleUrls: ['./suppliers-form.component.css']
})
export class SuppliersFormComponent implements OnInit {

  @Input() formSuppliers: FormGroup = this.formBuilder.group({
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

  @Input() btnText: string = 'Guardar';
  @Input() btnIcon: string = 'save';

  @Output() sendSupplier = new EventEmitter<Supplier>();
  
  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void { }

  onSubmit(): void {
    const supplier: Supplier = {
      companyName: this.companyName?.value,
      contactName: this.contactName?.value,
      contactTitle: this.contactTitle?.value,
      address: this.address?.value,
      city: this.city?.value,
      country: this.country?.value
    };

    if (this.supplierId?.value) supplier.id = this.supplierId?.value;

    this.sendSupplier.emit(supplier);

    this.onReset();
  }

  onReset(): void {
    this.formSuppliers.setValue({
      id: this.supplierId?.value,
      companyName: '',
      contactName: '',
      contactTitle: '',
      address: '',
      city: '',
      country: ''
    });
  }

  get supplierId() {
    return this.formSuppliers.get('id');
  }

  get companyName() {
    return this.formSuppliers.get('companyName');
  }

  get contactName() {
    return this.formSuppliers.get('contactName');
  }

  get contactTitle() {
    return this.formSuppliers.get('contactTitle');
  }

  get address() {
    return this.formSuppliers.get('address');
  }

  get city() {
    return this.formSuppliers.get('city');
  }

  get country() {
    return this.formSuppliers.get('country');
  }
}
