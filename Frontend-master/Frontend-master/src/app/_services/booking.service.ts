import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlSerializer } from '@angular/router';
import { map, Observable, toArray } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { Book } from '../_model/Book';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  book:Book={
    passenger_Name:'' ,
    city:'',
     country:'',
     passport_No :'',
   phoneNumber :'',
     gender:'',
    age:0,
   email:'',
  
}


  id!: number;
  user:any;
  data:any;

  reference!: number;
  baseUrl= environment.apiUrl;
  
  
  constructor(private http:HttpClient) { }
  
  // Observable<number>
  Book(id:number,model:Book) {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("id",this.id);
  return this.http.post(this.baseUrl +'Booking/Booking?id='+id,model).pipe(toArray()
  );
    }
 
    getHttpOptions(){
      console.log("hii");
      const userString = localStorage.getItem('user');
      if(!userString) return;
      const user =JSON.parse(userString);
      console.log(user)
      return{
        headers: new HttpHeaders({
          Authorization:'Bearer'+ user.token
        })
      }
    }
    SearchReference(id:number){
      let queryParams = new HttpParams();
      queryParams = queryParams.append("id",this.id);
     
    return this.http.get(this.baseUrl +'Booking/GetBookingDetails?id='+id).pipe(toArray()
    );
      }
}
