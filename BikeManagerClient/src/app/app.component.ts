import { Component, OnInit } from '@angular/core';
import { Bike } from './models/bike';
import { BikeService } from './services/bike.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'BikeManagerClient';

  bikeAvailList: Bike[];

  bikeRentList: Bike[];

  constructor(
    private bikeService: BikeService
  ) {}

  ngOnInit(){
    this.bikeService.getAvailBike().subscribe(x => {
      this.bikeAvailList = x;
    });

    this.bikeService.getRentBike().subscribe(x => {
      this.bikeRentList = x;
      console.log(x);
    });

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

  //update avail bikes after deleted
  updateAvailBikes(){
    this.bikeService.getAvailBike().subscribe(x => {
      this.bikeAvailList = x;
    });
  }

  //update rented bikes
  updateRentedBikes() {
    this.bikeService.getRentBike().subscribe(x => {
      this.bikeRentList = x;
    });
  }
}
