import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardService } from '../../../cores/services/dashboard.services';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.css']
})
export class DashboardComponent implements OnInit {

  role = '';

  upcomingAppointments = 0;
  healthRecordCount = 0;

  completedAppointments = 0;
  upcomingLeaves = 0;
  todayAppointments: any[] = [];

  constructor(
    private dashboardService: DashboardService
  ) { }

  ngOnInit(): void {

    this.role = localStorage.getItem('role') ?? '';

    if (this.role === 'Patient') {

      this.loadPatientDashboard();

    }
    else {

      this.loadDoctorDashboard();

    }

  }

  loadPatientDashboard() {

    this.dashboardService.getPatientDashboard()
      .subscribe({

        next: (response) => {

          this.upcomingAppointments = response.upcomingAppointments;

          this.healthRecordCount = response.healthRecordCount;

        },

        error: (err) => {

          console.log(err);

        }

      });

  }

  loadDoctorDashboard() {

    this.dashboardService.getDoctorDashboard()
      .subscribe({

        next: (response) => {

          this.upcomingAppointments = response.upcomingAppointments;

          this.completedAppointments = response.completedAppointments;

          this.upcomingLeaves = response.upcomingLeaves;

          this.todayAppointments = response.todayAppointments;

        },

        error: (err) => {

          console.log(err);

        }

      });

  }

}
