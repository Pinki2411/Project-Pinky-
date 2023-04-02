import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // cancelRegister:boolean=false;
 model:any={};


 constructor(private accountService:AccountService,private router:Router){}
 
 ngOnInit(): void {
   
 }
 register(){
  this.accountService.register(this.model).subscribe(
    {
      next:() =>{
        this.cancel();
      },
      error:error=>console.log(error)
    }
  )
  console.log(this.model);
 }
 cancel(){
  // this.cancelRegister=!this.cancelRegister;
  this.router.navigateByUrl('/')
 }
 
}
