import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Bike } from 'src/app/models/bike';
import { BikeService } from 'src/app/services/bike.service';
import { takeUntil } from 'rxjs/operators';
import { DestroyService } from 'src/app/services/destroy.service';

@Component({
  selector: 'app-create-bike',
  templateUrl: './create-bike.component.html',
  styleUrls: ['./create-bike.component.css']
})
export class CreateBikeComponent implements OnInit {

  bikeForm: FormGroup;
  bikeCategory: any = ['Highway', 'Mountain'];

  bike: Bike;

  constructor(
    private fb: FormBuilder,
    private bikeService: BikeService,
    private destroy$: DestroyService
  ) { 
    this.bikeFormCreate();
  }

  //create form
  bikeFormCreate(){
    this.bikeForm = this.fb.group({
      bikeName: ['', [Validators.required]],
      categoryName: ['', [Validators.required]],
      price: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
  }

  //added new bike to db
  onSubmit(){
    this.bike = this.bikeForm.value;
    this.bike.statusName = "Available";

    this.bikeService.createBike(this.bike)
    .pipe(takeUntil(this.destroy$))
    .subscribe(x => {
      this.bikeService.addedBike$.next(1);
    });

    this.bikeForm.reset();
  }

}
