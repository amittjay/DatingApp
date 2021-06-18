import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountsService } from 'src/Services/accounts.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private account: AccountsService, private toastr: ToastrService) { }
  canActivate(): Observable<boolean> {
    return this.account.Curentuser$.pipe(
      map(user => {     
        if (user) {
          return true
        }
        return false
      })
    );
  }

}
