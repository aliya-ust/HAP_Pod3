import { Component, OnInit, signal } from '@angular/core';
import { NgClass } from '@angular/common';
import { PatientService } from '../../core/services/patient.service';
import { ToastService } from '../../core/services/toast.service';
import { AppointmentListDto } from '../../core/models/appointment.models';
import { extractErrorMessage } from '../../core/utils/error-utils';

@Component({
  selector: 'app-my-appointments',
  standalone: true,
  imports: [NgClass],
  templateUrl: './my-appointments.html',
  styleUrl: './my-appointments.scss',
})
export class MyAppointments implements OnInit {
  appointments = signal<AppointmentListDto[]>([]);
  loading = signal(false);

  constructor(
    private readonly patientService: PatientService,
    private readonly toastService: ToastService,
  ) {}

  ngOnInit(): void {
    this.loadAppointments();
  }

  private loadAppointments(): void {
    this.loading.set(true);
    this.patientService.getUpcomingAppointments().subscribe({
      next: (res) => {
        this.appointments.set((res ?? []).filter(a => a.status !== 'Completed'));
        this.loading.set(false);
      },
      error: (err) => {
        this.loading.set(false);
        this.toastService.error(extractErrorMessage(err));
      },
    });
  }

  statusClass(status: string): string {
    switch (status) {
      case 'Pending': return 'badge-pending';
      case 'Confirmed': return 'badge-confirmed';
      case 'Cancelled': return 'badge-cancelled';
      case 'Completed': return 'badge-completed';
      default: return '';
    }
  }
}
