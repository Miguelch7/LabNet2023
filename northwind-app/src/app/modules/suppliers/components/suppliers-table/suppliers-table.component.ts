import { Component, OnInit } from '@angular/core';
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

  }

}
