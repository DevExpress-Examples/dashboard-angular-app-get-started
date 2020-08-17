import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'dashboard-angular-app';
  workingMode: string = 'Designer';
  get workingModeText() {
    return 'Switch to ' + this.toggleMode(this.workingMode);
  }
  
  changeWorkingMode() {    
    this.workingMode = this.toggleMode(this.workingMode);
  }
  toggleMode(mode) {
    return mode === 'Viewer' ? "Designer" : "Viewer";
  }

}