import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BikeRentDetailComponent } from './bike-rent-detail.component';

describe('BikeRentDetailComponent', () => {
  let component: BikeRentDetailComponent;
  let fixture: ComponentFixture<BikeRentDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BikeRentDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BikeRentDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
