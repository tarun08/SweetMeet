import { Component, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RegisterCreds, User } from '../../../app/types/user';
import { AccountService } from '../../../core/services/account-service';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  private accountService = inject(AccountService);
  membersFomHome = input.required<User[]>();
  protected cancelRegister = output<boolean>();
  protected creds = {} as RegisterCreds;

  protected register() {
    this.accountService.register(this.creds).subscribe({
      next: () => {
        this.cancelRegister.emit(false);
      },
      error: err => {
        console.log(err);
      }
    });
  }

  protected cancel() {
    this.cancelRegister.emit(false);
  }
}
