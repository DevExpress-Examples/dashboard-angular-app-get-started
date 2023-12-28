import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { DxDashboardControlModule } from 'devexpress-dashboard-angular';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
  	CommonModule, 
  	RouterOutlet, 
  	DxDashboardControlModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'dashboard-angular-app';
}
