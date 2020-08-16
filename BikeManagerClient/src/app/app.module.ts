import { AppComponent } from './app.component';
import { CreateBikeComponent } from './components/create-bike/create-bike.component';
import { BikeAvailListComponent } from './components/bike-avail-list/bike-avail-list.component';
import { BikeRentListComponent } from './components/bike-rent-list/bike-rent-list.component';
import { BikeRentDetailComponent } from './components/bike-rent-detail/bike-rent-detail.component';
import { BikeAvailDetailComponent } from './components/bike-avail-detail/bike-avail-detail.component';

import { MatCardModule } from '@angular/material/card';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BikeService } from './services/bike.service';
import { baseURL } from './shared/baseURL';
import { DestroyService } from './services/destroy.service';

@NgModule({
  declarations: [
    AppComponent,
    CreateBikeComponent,
    BikeAvailListComponent,
    BikeRentListComponent,
    BikeRentDetailComponent,
    BikeAvailDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [BikeService, DestroyService, {provide: 'baseUrl', useValue: baseURL}],
  bootstrap: [AppComponent]
})
export class AppModule { }
