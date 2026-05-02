import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { LoginCreds, RegisterCreds, User } from '../../app/types/user';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private http = inject(HttpClient);
  private baseUrl = "http://localhost:5101/api/"

  currentUser = signal<User | null>(null);

  login(creds: LoginCreds) {
    return this.http.post<User>(this.baseUrl + "accounts/login", creds).pipe(
      tap(response => {
        this.setCurrentUser(response);
      })
    )
  }

  private setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUser.set(user);
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }

  register(model: RegisterCreds) {
    return this.http.post<User>(this.baseUrl + 'accounts/register', model).pipe(
      tap(response => {
        this.setCurrentUser(response);
      })
    )
  }
}
