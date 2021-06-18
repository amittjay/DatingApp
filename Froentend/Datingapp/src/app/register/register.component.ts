import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountsService } from 'src/Services/accounts.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancleRegister = new EventEmitter();
  model: any = {};

  constructor(private acount: AccountsService , private toastr:ToastrService) { }

  ngOnInit(): void {
  }
  register() {
    this.acount.register(this.model).subscribe(responce => {
      console.log(responce)
      this.cancle();
    },
      error => {
        this.toastr.error(error.error)
        console.log(error)
      }
    )
  }
  cancle() {
    this.cancleRegister.emit(false);
  }

}
