import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';
import { Router, RouterLink, RouterLinkActive } from "@angular/router";
import { ToastService } from '../../core/services/toast-service';

@Component({
  selector: 'app-nav',
  imports: [FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrl: './nav.css',
})
export class Nav {
  protected accountService = inject(AccountService);
  protected toastService = inject(ToastService);
  private router = inject(Router)
  protected creds: any = {
    email: '',
    password: ''
  };



  login() {
    this.accountService.login(this.creds).subscribe({
      next: response => {
        this.router.navigateByUrl('/members');
        this.toastService.success("Logged in successfully", 5000)
        this.creds = {}
      },
      error: error => {
        this.toastService.error(error.error, 5000)
      }
    });
  }

  logout() {
    this.accountService.logout();
    this.toastService.info("Logged out successfully", 5000)
    this.router.navigateByUrl('/');
  }
}
