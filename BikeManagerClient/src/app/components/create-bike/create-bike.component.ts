import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Bike } from 'src/app/models/bike';
import { BikeService } from 'src/app/services/bike.service';

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
    private bikeService: BikeService
  ) { 
    this.bikeFormCreate();
  }

  bikeFormCreate(){
    this.bikeForm = this.fb.group({
      bikeName: ['', [Validators.required]],
      categoryName: ['', [Validators.required]],
      price: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
  }

  onSubmit(){
    this.bike = this.bikeForm.value;
    this.bike.statusName = "Available";

    console.log(this.bike);

    this.bikeService.createBike(this.bike).subscribe(x => {
      this.bikeService.addedBike$.next(1);
    });

    this.bikeForm.reset();
  }

}
