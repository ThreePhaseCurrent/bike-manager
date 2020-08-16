import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BikeAvailDetailComponent } from './bike-avail-detail.component';

describe('BikeAvailDetailComponent', () => {
  let component: BikeAvailDetailComponent;
  let fixture: ComponentFixture<BikeAvailDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BikeAvailDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BikeAvailDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
