import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCategoriesPageComponent } from './update-categories-page.component';

describe('UpdateCategoriesPageComponent', () => {
  let component: UpdateCategoriesPageComponent;
  let fixture: ComponentFixture<UpdateCategoriesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateCategoriesPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateCategoriesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
