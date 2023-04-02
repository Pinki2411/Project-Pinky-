import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddbookingComponent } from './Booking/addbooking/addbooking.component';
import { BookingDetailsComponent } from './Booking/booking-details/booking-details.component';
import { SearchReferenceComponent } from './Booking/search-reference/search-reference.component';
import { CheckinComponent } from './CheckIn/checkin/checkin.component';
//import { SearchFlightComponent } from './Flight/search-flight/search-flight.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './Login/login/login.component';
import { RegisterComponent } from './register/register.component';
import { RegisterComponent } from './register/register.component';
const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'Login',component:LoginComponent},
  {path:'Register',component:RegisterComponent},
  {path:'Flight/Getflight/:flight_Id',component:HomeComponent},
  {path:'Booking/Booking',component:AddbookingComponent},
  {path:'Booking/GetBookingDetails',component:SearchReferenceComponent},
  {path:'Booking/id',component:BookingDetailsComponent},
  {path:'CheckIn',component:CheckinComponent},
  {path:'**',component:HomeComponent,pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
