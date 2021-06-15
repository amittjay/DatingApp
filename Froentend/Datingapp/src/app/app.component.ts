import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Datingapp';
  user:any;
  constructor(private httpclinet:HttpClient){

  }
  ngOnInit(): void {
this.httpclinet.get('https://localhost:44371/api/users').subscribe(responce =>{
  this.user = responce;
},
error=>{
console.log(error());
}
)}}
