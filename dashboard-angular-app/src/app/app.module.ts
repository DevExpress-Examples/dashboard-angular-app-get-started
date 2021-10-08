import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DxDashboardControlModule } from 'devexpress-dashboard-angular';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    DxDashboardControlModule    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
