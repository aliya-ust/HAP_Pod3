import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppointmentService } from '../../../cores/services/appointments.services';
import { Appointment } from '../../../cores/models/Appointment';

@Component({
  selector: 'app-appointments',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './appointments.html',
  styleUrls: ['./appointments.css']
})
export class AppointmentsComponent implements OnInit {

  //  SIGNALS
  appointments = signal<Appointment[]>([]);
  loading = signal(true);

  patient = signal(false);
  doctor = signal(false);

  showViewDialog = signal(false);
  showAddDialog = signal(false);

  healthRecords = signal<any[]>([]);

  newRecord = signal({
    patientId: 0,
    diagnosis: '',
    prescription: '',
    notes: ''
  });

  selectedPatientId = signal(0);
  selectedAppointmentId = signal(0);

  constructor(
    private readonly appointmentService: AppointmentService,
    private readonly router: Router
  ) { }

  ngOnInit(): void {

    const role = localStorage.getItem('role')?.toLowerCase();

    this.patient.set(role === 'patient');
    this.doctor.set(role === 'doctor');

    console.log("Role:", role);

    this.loadAppointments(); // always call API
  }

  loadAppointments(): void {

    this.loading.set(true);

    if (this.patient()) {
      this.appointmentService.getPatientAppointments().subscribe({
        next: (data) => {
          console.log("Patient data:", data);
          this.appointments.set(data);
          this.loading.set(false);
        },
        error: (err) => {
          console.error(err);
          this.loading.set(false);
        }
      });
    }
    else if (this.doctor()) {
      this.appointmentService.getDoctorAppointments().subscribe({
        next: (data) => {
          console.log("Doctor data:", data);
          this.appointments.set(data);
          this.loading.set(false);
        },
        error: (err) => {
          console.error(err);
          this.loading.set(false);
        }
      });
    }
  }

  confirmAppointment(id: number): void {
    this.appointmentService.confirmAppointment(id).subscribe({
      next: () => this.loadAppointments(),
      error: err => console.error(err)
    });
  }

  cancelAppointment(id: number): void {
    this.appointmentService.cancelAppointment(id).subscribe({
      next: () => this.loadAppointments(),
      error: err => console.error(err)
    });
  }

  viewHealthRecord(patientId: number): void {

    this.selectedPatientId.set(patientId);

    this.appointmentService.getHealthRecordsByPatient(patientId).subscribe({
      next: (data) => {
        this.healthRecords.set(data);
        this.showViewDialog.set(true);
      },
      error: err => console.error(err)
    });
  }

  addHealthRecord(appointmentId: number, patientId: number): void {

    this.selectedAppointmentId.set(appointmentId);
    this.selectedPatientId.set(patientId);

    this.newRecord.set({
      patientId: patientId,
      diagnosis: '',
      prescription: '',
      notes: ''
    });

    this.showAddDialog.set(true);
  }

  submitHealthRecord(): void {

    const appointment = this.appointments()
      .find(a => a.appointmentId === this.selectedAppointmentId());

    const dto = {
      ...this.newRecord(),
      patientId: this.selectedPatientId(),
      appointmentId: this.selectedAppointmentId(),
      VisitDate: appointment?.scheduledDate //  CORRECT FIELD
    };

    console.log("Visit Date:", dto.VisitDate); //  debug

    this.appointmentService.createHealthRecord(dto).subscribe({
      next: () => {
        alert('Health record added successfully');
        this.showAddDialog.set(false);
        this.loadAppointments();
      },
      error: err => console.error(err)
    });
  }


}
