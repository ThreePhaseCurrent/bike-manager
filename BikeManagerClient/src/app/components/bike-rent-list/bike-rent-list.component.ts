import { Component, OnInit, Input } from '@angular/core';
import { Bike } from 'src/app/models/bike';

@Component({
  selector: 'app-bike-rent-list',
  templateUrl: './bike-rent-list.component.html',
  styleUrls: ['./bike-rent-list.component.css']
})
export class BikeRentListComponent implements OnInit {

  @Input()
  bikeList: Bike[];

  constructor() { }

  ngOnInit(): void {
  }

  //calc price all bikes
  caclPrice(): number{
    var summ = 0;
    this.bikeList.forEach(x => {
      summ += x.price;
    });
    
    return summ;
  }

}
