import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { toArray } from 'rxjs';
import { CheckinComponent } from 'src/app/CheckIn/checkin/checkin.component';
import { BookingService } from 'src/app/_services/booking.service';

@Component({
  selector: 'app-search-reference',
  templateUrl: './search-reference.component.html',
  styleUrls: ['./search-reference.component.css']
})
export class SearchReferenceComponent implements OnInit {
 Id:any;
 data:any;
 res: any[] = [];
 flight:any;
  To: any;
  From: any;
  Date: any;
  fid:number=0;
  Details:any;
  Fare: any;
  Name: any;
  show:boolean=false;
  showCheckInpage=false;
  
  // @ViewChild('checkin')
  // checkin: CheckinComponent;
  constructor(private http:HttpClient,private router: Router,private bookService:BookingService,private Checkin:CheckinComponent){
    

  }
  ngOnInit(): void {
    
  }
  SearchR()
  {
  this.bookService.SearchReference(this.Id).subscribe(
    {
        next:response=>this.data=response,
        error:error=>console.log(error),
       complete:()=> console.log('Request has completed')
  });
     this.ShowDetails()
      }
      ShowDetails()
      {
        this.show=!this.show;

      }
      callFunction(id:number){
        console.log(id);
        localStorage.setItem('BookingId',JSON.stringify(id));
        this.showCheckInpage=!this.showCheckInpage;
      }
      
    }
   
    


