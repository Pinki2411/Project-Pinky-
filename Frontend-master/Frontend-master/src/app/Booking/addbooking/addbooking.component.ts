import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';

import { BookingService } from 'src/app/_services/booking.service';


@Component({
  selector: 'app-addbooking',
  templateUrl: './addbooking.component.html',
  styleUrls: ['./addbooking.component.css']
})
export class AddbookingComponent implements OnInit{
   @Input()flights :any[] = [];
  model:any={};
  Id!: number;
  flight:any;
  data:any;
  To: any;
  From: any;
  Date: any;
  Fare: any;
  Name: any;
  IsshowReferenceNo=false;
 
  


  constructor(private bookService:BookingService){
    
    
}
  ngOnInit(): void {
    const [To,From,Date,Fare,Name,Id  ] = this.flights;
    this.To=To;
    this.From=From;
    this.Date=Date;
    this.Fare=Fare;
    this.Name=Name;
    this.Id=Id;
    console.log(Id);
    
  }

  
  Booking(){
    this.bookService.Book(this.Id,this.model).subscribe(
      {
        next:response=>{
          this.data=response;
           console.log(this.data);
          this.showReferenceNo();
        },
        error:error =>console.log(error),
        
      }
    )
  }
  // getHttpOptions(){
  //   const userString = localStorage.getItem('user');
  //   if(!userString) return;
  //   const user =JSON.parse(userString);
  //   const token=user.token;
  //   console.log(token);
  //   const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  //   return headers;
      // headers: new HttpHeaders({
      //   Authorization:'Bearer'+ user.token
      // })
     
    
  //}
  showReferenceNo()
 {
 this.IsshowReferenceNo=!this.IsshowReferenceNo
 }

}
