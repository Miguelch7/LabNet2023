import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from '../../models/Category';

@Component({
  selector: 'app-categories-form',
  templateUrl: './categories-form.component.html',
  styleUrls: ['./categories-form.component.css']
})
export class CategoriesFormComponent implements OnInit {

  formCategories!: FormGroup;

  @Input() category: Category = {
    categoryName: '',
    description: ''
  };
  @Output() sendCategory = new EventEmitter<Category>();

  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.formCategories = this.formBuilder.group({
      categoryName: [
        this.category.categoryName, 
        [Validators.required, Validators.minLength(3)]
      ],
      description: [
        this.category.description
      ]
    })
  }

  onSubmit(): void {
    this.category = { 
      categoryName: this.categoryName?.value, 
      description: this.description?.value, 
    };

    this.sendCategory.emit(this.category);
    this.onReset();
  }

  onReset(): void {
    this.formCategories = this.formBuilder.group({
      categoryName: ['', [Validators.required, Validators.minLength(3)]],
      description: ['']
    });
  }

  get categoryName() {
    return this.formCategories.get('categoryName');
  }

  get description() {
    return this.formCategories.get('description');
  }

}
