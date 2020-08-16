import { Component, OnInit } from '@angular/core';
import { Bike } from './models/bike';
import { BikeService } from './services/bike.service';
import { DestroyService } from './services/destroy.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'BikeManagerClient';

  //available bikes list
  bikeAvailList: Bike[];
  //rented bikes list    
  bikeRentList: Bike[];

  constructor(
    private bikeService: BikeService,
    private destroy$: DestroyService
  ) {}

  ngOnInit(){
    this.updateAvailBikes();
    this.updateRentedBikes();

    //event deleted bike
    this.bikeService.deletedBike$.subscribe(x => {
      if(x !== 0) {
        console.log(x);
        this.updateAvailBikes();
      }
    });

    //event added bike
    this.bikeService.addedBike$.subscribe(x => {
      if(x !== 0) {
        console.log(x);
        this.updateAvailBikes();
      }
    });

    //event rented bike
    this.bikeService.rentedBike$.subscribe(x => {
      if(x !== 0) {
        console.log(x);
        this.updateRentedBikes();
        this.updateAvailBikes();
      }
    });

    //event cancel bike rent
    this.bikeService.cancelRentBike$.subscribe(x => {
      if(x !== 0) {
        console.log(x);
        this.updateRentedBikes();
        this.updateAvailBikes();
      }
    });
  }

  //update avail bikes
  updateAvailBikes(){
    this.bikeService.getAvailBike().pipe(takeUntil(this.destroy$)).subscribe(x => {
      this.bikeAvailList = x;
    });
  }

  //update rented bikes
  updateRentedBikes() {
    this.bikeService.getRentBike().pipe(takeUntil(this.destroy$)).subscribe(x => {
      this.bikeRentList = x;
    });
  }
}
