import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Category } from '../../models/Category';

@Component({
  selector: 'app-categories-form',
  templateUrl: './categories-form.component.html',
  styleUrls: ['./categories-form.component.css']
})
export class CategoriesFormComponent implements OnInit {

  @Input() formCategories: FormGroup = this.formBuilder.group({
    id: null,
    categoryName: [
      '', 
      [Validators.required, Validators.minLength(3)]
    ],
    description: ['']
  });

  @Output() sendCategory = new EventEmitter<Category>();

  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void { }

  onSubmit(): void {
    const category: Category = {
      categoryName: this.categoryName?.value, 
      description: this.description?.value
    };

    if (this.categoryId?.value) category.id = this.categoryId?.value;

    this.sendCategory.emit(category);

    this.onReset();
  }

  onReset(): void {
    this.formCategories.setValue({
      id: this.categoryId?.value,
      categoryName: '',
      description: ''
    });
  }

  get categoryId() {
    return this.formCategories.get('id');
  }

  get categoryName() {
    return this.formCategories.get('categoryName');
  }

  get description() {
    return this.formCategories.get('description');
  }
}
