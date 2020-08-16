import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { templateJitUrl } from '@angular/compiler';
import { baseURL } from '../shared/baseURL';
import { Bike } from '../models/bike';

@Injectable({
  providedIn: 'root'
})
export class BikeService {

  constructor(
    private http: HttpClient
  ) { }

  //event success deleted bike from db 
  deletedBike$ = new BehaviorSubject<number>(0);
  //event success added bike to db 
  addedBike$ = new BehaviorSubject<number>(0);
  //event success rented bike
  rentedBike$ = new BehaviorSubject<number>(0);
  //event success cancel renting bike
  cancelRentBike$ = new BehaviorSubject<number>(0);

  //create new bike
  createBike(bike: Bike): Observable<any> {
    return this.http.post(`${baseURL}bikes`, {
      BikeName: bike.bikeName,
      CategoryName: bike.categoryName,
      StatusName: bike.statusName,
      Price: bike.price
    });
  }

  //get available bikes from server
  getAvailBike(): Observable<Bike[]> {
    return this.http.get<Bike[]>(`${baseURL}bikes/available`);
  }

  //get rented bikes from server
  getRentBike(): Observable<Bike[]> {
    return this.http.get<Bike[]>(`${baseURL}bikes/rented`);
  }

  //delete bike from server by id
  deleteBikeById(id: number): Observable<any> {
    return this.http.delete(`${baseURL}bikes/` + id);
  }

  //rent bike by id
  rentBike(id: number): Observable<any> {
    return this.http.put(`${baseURL}bikes?id=` + id + `&toStatus=Rented`, {});
  }

  //cancel renting bike by id
  cancelRentBike(id: number) {
    return this.http.put(`${baseURL}bikes?id=` + id + `&toStatus=Available`, {})
  }
}
