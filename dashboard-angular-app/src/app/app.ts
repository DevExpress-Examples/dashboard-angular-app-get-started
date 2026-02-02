import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DxDashboardControlModule } from 'devexpress-dashboard-angular';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    DxDashboardControlModule
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('dashboard-angular-app');
}
