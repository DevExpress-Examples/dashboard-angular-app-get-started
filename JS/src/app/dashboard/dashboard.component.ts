import { Component, AfterViewInit, ElementRef, OnDestroy } from '@angular/core';
import { DashboardControl, ResourceManager } from 'devexpress-dashboard';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})

export class DashboardComponent implements AfterViewInit, OnDestroy {
  private dashboardControl!: DashboardControl;
  constructor(private element: ElementRef) {
    ResourceManager.embedBundledResources();
  }
  ngAfterViewInit(): void {
    this.dashboardControl = new DashboardControl(this.element.nativeElement.querySelector(".dashboard-container"), {
      // Specifies a URL of the Web Dashboard's server.
      endpoint: "https://demos.devexpress.com/services/dashboard/api",
      workingMode: "Designer",
    });

    this.dashboardControl.render();
  }
  ngOnDestroy(): void {
    this.dashboardControl && this.dashboardControl.dispose();
  }
}