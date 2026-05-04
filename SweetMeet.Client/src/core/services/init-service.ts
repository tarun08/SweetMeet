import { inject, Injectable } from '@angular/core';
import { AccountService } from './account-service';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InitService {
  private accountService = inject(AccountService);

  init(): Observable<null> {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      this.accountService.currentUser.set(JSON.parse(storedUser));
    }
    return of(null)
  }
}
