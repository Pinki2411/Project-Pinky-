import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService } from '../_services/account.service';
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{
  registerMode=false;
  model:any={};
  Isfalse:boolean=true;


  constructor(public accountService: AccountService,private router:Router){
      
  }

  ngOnInit(): void {
  
  }

  login(){
    this.accountService.login(this.model).subscribe({
      next:response=>{
        console.log(response);
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
