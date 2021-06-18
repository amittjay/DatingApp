import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Users } from 'src/Models/Users';
import { AccountsService } from 'src/Services/accounts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Datingapp';
  constructor(private acount:AccountsService){

  }
  ngOnInit(): void {
  
}
setCurrentUser(){
  // const user:User=JSON.parse(localStorage.getItem('')||'{}');
  const user :Users = JSON.parse(localStorage.getItem('user')||'{}');
   this.acount.SetCurrentuser(user);
}

}
