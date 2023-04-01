import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateSuppliersPageComponent } from './update-suppliers-page.component';

describe('UpdateSuppliersPageComponent', () => {
  let component: UpdateSuppliersPageComponent;
  let fixture: ComponentFixture<UpdateSuppliersPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateSuppliersPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateSuppliersPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
