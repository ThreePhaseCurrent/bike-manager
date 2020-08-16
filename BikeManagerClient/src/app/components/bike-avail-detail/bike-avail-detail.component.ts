import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { Bike } from 'src/app/models/bike';
import { BikeService } from 'src/app/services/bike.service';

@Component({
  selector: 'app-bike-avail-detail',
  templateUrl: './bike-avail-detail.component.html',
  styleUrls: ['./bike-avail-detail.component.css']
})
export class BikeAvailDetailComponent implements OnInit {

  @Input()
  bike: Bike;

  constructor(
    private bikeService: BikeService
  ) { }

  ngOnInit(): void {
  }

  onDelete(){
    this.bikeService.deleteBikeById(this.bike.id).subscribe((result) => {
      this.bikeService.deletedBike$.next(this.bike.id);
    });
  }

  onRent(){
    this.bikeService.rentBike(this.bike.id).subscribe(x => {
      this.bikeService.rentedBike$.next(1);
    });
  }
}
