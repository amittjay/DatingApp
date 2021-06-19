import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {
  baseUrl = 'https://localhost:44371/api/';
  ValidationErrors:string[] =[];
  constructor(private http: HttpClient,private toastr:ToastrService) { }

  ngOnInit(): void {
  }
  get404Errors() {
    this.http.get(this.baseUrl + 'Buggy/NotFound').subscribe(responce => {
      console.log(responce)
    }, error => {
      this.toastr.error(error);
      console.log(error)
    }
    )
  }

  get400Errors() {
    this.http.get(this.baseUrl + 'Buggy/Bad-Request').subscribe(responce => {
      console.log(responce)
    }, error => {
      console.log(error)
    }
    )
  }

  get500Errors() {
    this.http.get(this.baseUrl + 'Buggy/Server-error').subscribe(responce => {
      console.log(responce)
    }, error => {
      
      console.log(error)
    }
    )
  }

  get401Errors() {
    this.http.get(this.baseUrl + 'Buggy/Auth').subscribe(responce => {
      console.log(responce)
    }, error => {
      console.log(error)
    }
    )
  }

  get400ValidationsErrors() {
    this.http.post(this.baseUrl + 'account/register',{}).subscribe(responce => {
      console.log(responce)
    }, error => {
      console.log(error)
      this.ValidationErrors = error;
    }
    )
  }

}
