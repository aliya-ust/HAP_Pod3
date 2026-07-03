import { CommonModule } from '@angular/common';
import { Component, OnInit, computed } from '@angular/core';
import { AppointmentService } from '../../core/services/appointment.service';
import { PatientService } from '../../core/services/patient.service';

@Component({
  selector: 'app-patient-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './patient-dashboard.html',
  styleUrl: './patient-dashboard.css'
})
export class PatientDashboard implements OnInit {
  upcomingAppointmentsCount = computed(() =>
    this.appointmentService.patientAppointments().length
  );

  latestHealthRecordsCount = computed(() =>
    this.patientService.records().length
  );

  constructor(
    public appointmentService: AppointmentService,
    public patientService: PatientService
  ) { }

  ngOnInit(): void {
    this.appointmentService.loadPatientAppointments();
    this.patientService.loadRecords();
  }
}
