import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BikeRentListComponent } from './bike-rent-list.component';

describe('BikeRentListComponent', () => {
  let component: BikeRentListComponent;
  let fixture: ComponentFixture<BikeRentListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BikeRentListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BikeRentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
