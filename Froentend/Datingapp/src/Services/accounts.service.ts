import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators'
import { Users } from 'src/Models/Users';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {
  baseUrl = 'https://localhost:44371/api/';
  private currentUserSource = new ReplaySubject<Users>(1);
  Curentuser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post<Users>(this.baseUrl + 'Account/Login', model).pipe(

      map((Response: Users) => {
        const user = Response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user))
          this.currentUserSource.next(user);
        }
      })
    )
  }
  register(model: any) {
    return this.http.post<Users>(this.baseUrl + 'Account/Register', model).pipe(
      map((user: Users) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user))
          this.currentUserSource.next(user);
        }
        return user;
      })
    )
  }
  SetCurrentuser(user: Users) {
    this.currentUserSource.next(user);
  }


  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next();
  }
}
