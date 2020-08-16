import { Component, OnInit, Input } from '@angular/core';
import { Bike } from 'src/app/models/bike';
import { BikeService } from 'src/app/services/bike.service';
import { DestroyService } from 'src/app/services/destroy.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-bike-avail-detail',
  templateUrl: './bike-avail-detail.component.html',
  styleUrls: ['./bike-avail-detail.component.css']
})
export class BikeAvailDetailComponent implements OnInit {

  @Input()
  bike: Bike;

  constructor(
    private bikeService: BikeService,
    private destroy$: DestroyService
  ) { }

  ngOnInit(): void {
  }

  //delete bike
  onDelete(){
    this.bikeService.deleteBikeById(this.bike.id)
    .pipe(takeUntil(this.destroy$))
    .subscribe((result) => {
      this.bikeService.deletedBike$.next(this.bike.id);
    });
  }

  //rent bike
  onRent(){
    this.bikeService.rentBike(this.bike.id)
    .pipe(takeUntil(this.destroy$))
    .subscribe(x => {
      this.bikeService.rentedBike$.next(1);
    });
  }
}
