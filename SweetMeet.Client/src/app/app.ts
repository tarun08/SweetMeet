import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { Nav } from "../layout/nav/nav";
import { AccountService } from '../core/services/account-service';
import { Home } from "../features/home/home";
import { User } from './types/user';

@Component({
  selector: 'app-root',
  imports: [Nav, Home],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  private accountService = inject(AccountService);
  private http = inject(HttpClient);
  protected readonly title = signal('Sweet Meet');
  protected members = signal<User[]>([]);

  ngOnInit() {
    this.setCurrentUserFromLocalStorage();
    this.getMembers();
  }

  setCurrentUserFromLocalStorage() {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      this.accountService.currentUser.set(JSON.parse(storedUser));
    }
  }

  async getMembers() {
    this.http.get<User[]>('http://localhost:5101/api/members').subscribe({
      next: response => this.members.set(response),
      error: err => console.log(err),
      complete: () => console.log('Completed request.')
    });
  }
}
