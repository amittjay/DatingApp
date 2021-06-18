import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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

  constructor(public acount:AccountsService,private route:Router,private toastr:ToastrService) { }

  ngOnInit(): void {
    this.login();
    this.currentUser$= this.acount.Curentuser$;
  }
  login(){
    this.acount.login(this.model).subscribe(responce=>{
      console.log(responce);
      this.route.navigateByUrl('/members');
    },error=>{
      this.toastr.error(error.error)
      console.log(error);
    }
    )
  }
  logout(){
    this.acount.logout();
    this.route.navigateByUrl('/');
  }

}
