import { Component, Input, OnInit } from '@angular/core';
import { Category } from '../../models/Category';

@Component({
  selector: 'app-categories-table',
  templateUrl: './categories-table.component.html',
  styleUrls: ['./categories-table.component.css']
})
export class CategoriesTableComponent implements OnInit {

  @Input() categoriesList: Array<Category> = [];

  constructor() { }

  ngOnInit(): void {
  }

}
