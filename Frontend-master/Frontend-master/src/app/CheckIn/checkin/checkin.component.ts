import { Component, OnInit } from '@angular/core';
import { CheckInService } from 'src/app/_services/checkIn.service';

@Component({
  selector: 'app-checkin',
  templateUrl: './checkin.component.html',
  styleUrls: ['./checkin.component.css']
})
export class CheckinComponent implements OnInit {
data:any;
Id:any;
show=false;
  myarray:any;
  CheckinId:number=0;
  seatNum:number=0;
constructor(private checkinservice:CheckInService){
  this.myarray=localStorage.getItem('BookingId');
  // this.myarray = localStorage.getItem('BookingId');
  if (this.myarray !== null) {
    this.myarray = parseInt(this.myarray,10);
    console.log(this.myarray);
    
}
}
  ngOnInit(): void {
    this.CheckIN(this.myarray);
  }
 CheckIN(id:number)
 {

  this.checkinservice.CheckIn(id).subscribe(
    {
        next:response=>this.data=response,
        error:error=>console.log(error),
        complete:()=> console.log(this.data)
   });
   //localStorage.removeItem('BookingId'); 
 }

}
