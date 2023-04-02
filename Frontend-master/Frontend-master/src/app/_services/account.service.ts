import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { User } from '../_model/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
 baseUrl= environment.apiUrl;
 private currentUserSource= new BehaviorSubject<User | null>(null);
 currentUser$ = this.currentUserSource.asObservable();

  constructor(private http:HttpClient) { }

  login(model:any){
    return this.http.post<User>(this.baseUrl +'Registration/Login',model).pipe(
      map((response:User)=>{
        const user = response;
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }
 register(model:any){
    return this.http.post<User>(this.baseUrl +'Registration/Registration',model).pipe(
      map((user)=>{
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      }))
    }
  setCurrentUser(user:User)
  {
    this.currentUserSource.next(user)
  }
  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
  getToken(){
    return localStorage.getItem('user')
  }
  IsloggedIn():boolean{
    return !!localStorage.getItem('user');
  }
  
}
