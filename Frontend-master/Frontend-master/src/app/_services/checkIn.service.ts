import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable, toArray } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { Flight } from '../_model/flights';

@Injectable({
  providedIn: 'root'
})
export class CheckInService implements OnInit {
  baseUrl='http://localhost:5287/api/';
 
  data:any=[];

 model:any;

  constructor(private http:HttpClient) { }
  ngOnInit(): void {
    
  }
  CheckIn(id:number) {
    let queryParams = new HttpParams();
    queryParams = queryParams.append("id",id);
    // ,{params:queryParams }
  return this.http.post(this.baseUrl +'CheckIn/CheckIn?id='+id,this.model).pipe(toArray()
  );
    }
 
  }
//  getHttpOptions(){
// const userString = localStorage.getItem('user');
// if(!userString) return;
// const user =JSON.parse(userString);
// return{
//   headers: new HttpHeaders({
//     Authorization:'Bearer'+ user.token
//   })
// }
//   }

