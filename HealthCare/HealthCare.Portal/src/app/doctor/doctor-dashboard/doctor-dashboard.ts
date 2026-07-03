import { CommonModule } from '@angular/common';
import { Component, OnInit, computed } from '@angular/core';
import { DoctorService } from '../../core/services/doctor.service';

@Component({
  selector: 'app-doctor-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './doctor-dashboard.html',
  styleUrl: './doctor-dashboard.css'
})
export class DoctorDashboard implements OnInit {

  summary = computed(() => this.doctorService.dashboardSummary());

  constructor(public doctorService: DoctorService) { }

  ngOnInit(): void {
    this.doctorService.loadDashboardSummary();
  }
}
