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

  createBike(bike: Bike): Observable<any>{
    return this.http.post(`${baseURL}bikes`, {
      BikeName: bike.bikeName,
      CategoryName: bike.categoryName,
      StatusName: bike.statusName,
      Price: bike.price
    });
  }

  deletedBike$ = new BehaviorSubject<number>(0);
  addedBike$ = new BehaviorSubject<number>(0);
  rentedBike$ = new BehaviorSubject<number>(0);
  cancelRentBike$ = new BehaviorSubject<number>(0);

  getAvailBike(): Observable<Bike[]>{
    return this.http.get<Bike[]>(`${baseURL}bikes/available`);
  }

  getRentBike(): Observable<Bike[]> {
    return this.http.get<Bike[]>(`${baseURL}bikes/rented`);
  }

  deleteBikeById(id: number): Observable<any> {
    return this.http.delete(`${baseURL}bikes/` + id);
  }

  rentBike(id: number): Observable<any> {
    return this.http.put(`${baseURL}bikes?id=` + id + `&toStatus=Rented`, {});
  }

  cancelRentBike(id: number){
    return this.http.put(`${baseURL}bikes?id=` + id + `&toStatus=Available`, {})
  }
}
