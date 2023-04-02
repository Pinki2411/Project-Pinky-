import {  NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule} from 'ngx-bootstrap/dropdown';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
//import { SearchFlightComponent } from './Flight/search-flight/search-flight.component';
import { AddbookingComponent } from './Booking/addbooking/addbooking.component';
import { CheckinComponent } from './CheckIn/checkin/checkin.component';
//import { FlightDetailsComponent } from './Flight/flight-details/flight-details.component';
import { BookingDetailsComponent } from './Booking/booking-details/booking-details.component';
import { SearchReferenceComponent } from './Booking/search-reference/search-reference.component';
import { LoginComponent } from './Login/login/login.component';
// import { MbscModule } from '@mobiscroll/angular-lite';




@NgModule({

  declarations: [
    AppComponent,
    NavComponent,
    RegisterComponent,
    HomeComponent,
    AddbookingComponent,
    CheckinComponent,
   // FlightDetailsComponent,
    BookingDetailsComponent,
   SearchReferenceComponent,
   LoginComponent
  ],
  imports: [
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [CheckinComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
