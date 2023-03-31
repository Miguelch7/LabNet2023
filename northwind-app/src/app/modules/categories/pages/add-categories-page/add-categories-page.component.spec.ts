import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCategoriesPageComponent } from './add-categories-page.component';

describe('AddCategoriesPageComponent', () => {
  let component: AddCategoriesPageComponent;
  let fixture: ComponentFixture<AddCategoriesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCategoriesPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddCategoriesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
