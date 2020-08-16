import { Component, OnInit, Input } from '@angular/core';
import { Bike } from 'src/app/models/bike';
import { BikeService } from 'src/app/services/bike.service';
import { takeUntil } from 'rxjs/operators';
import { DestroyService } from 'src/app/services/destroy.service';

@Component({
  selector: 'app-bike-rent-detail',
  templateUrl: './bike-rent-detail.component.html',
  styleUrls: ['./bike-rent-detail.component.css']
})
export class BikeRentDetailComponent implements OnInit {

  @Input()
  bike: Bike;
  
  constructor(
    private bikeService: BikeService,
    private destroy$: DestroyService
  ) { }

  ngOnInit(): void {
  }

  //cancel rent bike
  onCancel(){
    this.bikeService.cancelRentBike(this.bike.id)
    .pipe(takeUntil(this.destroy$))
    .subscribe(x => {
      this.bikeService.cancelRentBike$.next(1);
    });
  }

}
