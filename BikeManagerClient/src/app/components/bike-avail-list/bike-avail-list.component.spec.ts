import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BikeAvailListComponent } from './bike-avail-list.component';

describe('BikeAvailListComponent', () => {
  let component: BikeAvailListComponent;
  let fixture: ComponentFixture<BikeAvailListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BikeAvailListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BikeAvailListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
