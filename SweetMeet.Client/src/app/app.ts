import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {

  private http = inject(HttpClient);
  protected readonly title = signal('SweetMeet.Client');
  protected members = signal<any>([]);

  ngOnInit(): void {
    this.http.get('http://localhost:5101/api/members').subscribe({
      next: response => this.members.set(response),
      error: err => console.log(err),
      complete: () => console.log('Completed request.')
    });
  }

}
