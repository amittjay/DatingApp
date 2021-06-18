import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Users } from 'src/Models/Users';
import { AccountsService } from 'src/Services/accounts.service';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  currentUser$:Observable<Users> | undefined;
  model:any ={}

  constructor(private acount:AccountsService) { }

  ngOnInit(): void {
    this.login();
    this.currentUser$= this.acount.Curentuser$;
  }
  login(){
    this.acount.login(this.model).subscribe(responce=>{
      console.log(responce);
    },error=>{
      console.log(error);
    }
    )
  }
  logout(){
    this.acount.logout();
  }

}
