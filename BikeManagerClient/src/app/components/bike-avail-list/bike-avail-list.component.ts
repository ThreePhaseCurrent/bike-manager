import { Component, OnInit, Input } from '@angular/core';
import { Bike } from 'src/app/models/bike';

@Component({
  selector: 'app-bike-avail-list',
  templateUrl: './bike-avail-list.component.html',
  styleUrls: ['./bike-avail-list.component.css']
})
export class BikeAvailListComponent implements OnInit {

  @Input()
  bikeList: Bike[];

  constructor() { }

  ngOnInit(): void {
  }
}
