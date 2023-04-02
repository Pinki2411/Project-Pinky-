import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  registerMode=false;
  model:any={};
  Isfalse:boolean=true;
  constructor(public accountService: AccountService,private router:Router){

  }
  login(){
    this.accountService.login(this.model).subscribe({
      next:response=>{
        console.log(response);
        this.router.navigateByUrl('/')
      },
      error:error =>console.log(error)
      
    })
  }
  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/')
  }
  registerToggle(){
    this.registerMode=!this.registerMode;
    this.Isfalse=false;
   }
   cancelRegisterMode(event:boolean){
    this.Isfalse=true;
    this.registerMode=event;
   }
}
