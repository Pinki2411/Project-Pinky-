import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

   baseUrl='http://localhost:5287/api/';
   registerMode=false;
   SearchButton=false;
   BookButton=false;
   hideElement=false;
   Id:number=0;
   to!: string;
   from!: string;
   date:any;
   flights:any; 
   flight:any;
   data: any;
   res: any[] = [];
   From!: string[];
   To!: string[];
   min!: Date;
   max!:Date;
   images = [
    'assets\\Image\\image1.jpg',
    'assets\\Image\\image2.jpg',
    'assets\\Image\\image3.jpg'
  ];





 constructor(private http:HttpClient,private router: Router,private cdr: ChangeDetectorRef){

 }
 ngOnInit():void{
  this.http.get<string[]>(this.baseUrl + 'Flight/From').subscribe({
    next:response=> this.From=response,
   
        error:error=>console.log(error),
    complete:()=> console.log('Request has completed')
  });
  this.http.get<string[]>(this.baseUrl + 'Flight/To').subscribe({
    next:response=> this.To=response,
    error:error=>console.log(error),
    complete:()=> console.log('Request has completed')
  });
}

 


SearchButtonClick(){
  this.SearchButton=!this.SearchButton;
}
  

 loadflight(){
  this.SearchButtonClick()
   let queryParams = new HttpParams();
  queryParams = queryParams.append("date",this.date);
  queryParams = queryParams.append("from",this.from);
  queryParams = queryParams.append("to",this.to);
  return this.http.get(this.baseUrl + 'Flight/Search',{params:queryParams}).subscribe({
    next:response=>this.flights=response,
   
        error:error=>console.log(error),
    complete:()=> console.log('Request has completed')
  })
}
getflight(flight_Id:any)
{
   let queryParams = new HttpParams();
   queryParams = queryParams.append("id",flight_Id);
   return this.http.get(this.baseUrl + 'Flight/Getflight/',{params:queryParams }).subscribe(flight =>{
     localStorage.setItem('flight',JSON.stringify(flight));
     this.flight=localStorage.getItem('flight');
     console.log(this.flight);
     const data=JSON.parse(this.flight);
     console.log(data);

     for(var i in data)
     this. res.push(data[i]);

     console.log(this.res);
     this.ShowBooking();

  })
 
  
 }
ShowBooking()
 { 
 
   this.BookButton=!this.BookButton;
   this. hideElement=true;

}
  ngAfterViewInit() {
}




swapValues() {
  const temp = this.to;
  console.log(temp);
  this.to = this.from;
  console.log(this.to);
  this.from = temp;
  console.log(this.from);
  this.cdr.detectChanges();
}
}

