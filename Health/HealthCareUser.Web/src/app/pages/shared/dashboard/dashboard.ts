import { Component, OnInit, signal } from '@angular/core';
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

  role = signal('');

  upcomingAppointments = signal(0);
  healthRecordCount = signal(0);

  completedAppointments = signal(0);
  upcomingLeaves = signal(0);
  todayAppointments = signal<any[]>([]);

  constructor(private readonly dashboardService: DashboardService) { }

  ngOnInit(): void {

    const roleValue = localStorage.getItem('role') ?? '';
    this.role.set(roleValue);

    if (roleValue === 'Doctor') {
      this.loadDoctorDashboard();
    }
    else if (roleValue === 'Patient') {
      this.loadPatientDashboard();
    }
  }

  loadPatientDashboard() {

    this.dashboardService.getPatientDashboard()
      .subscribe({

        next: (response) => {

          this.upcomingAppointments.set(response.upcomingAppointments);
          this.healthRecordCount.set(response.healthRecordCount);

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

          this.upcomingAppointments.set(response.upcomingAppointments);
          this.completedAppointments.set(response.completedAppointments);
          this.upcomingLeaves.set(response.upcomingLeaves);
          this.todayAppointments.set(response.todayAppointments);

        },

        error: (err) => {
          console.log(err);
        }

      });
  }

}
