import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsSuppliersPageComponent } from './details-suppliers-page.component';

describe('DetailsSuppliersPageComponent', () => {
  let component: DetailsSuppliersPageComponent;
  let fixture: ComponentFixture<DetailsSuppliersPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsSuppliersPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailsSuppliersPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
