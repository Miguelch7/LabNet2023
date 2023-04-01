import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSuppliersPageComponent } from './add-suppliers-page.component';

describe('AddSuppliersPageComponent', () => {
  let component: AddSuppliersPageComponent;
  let fixture: ComponentFixture<AddSuppliersPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSuppliersPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddSuppliersPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
