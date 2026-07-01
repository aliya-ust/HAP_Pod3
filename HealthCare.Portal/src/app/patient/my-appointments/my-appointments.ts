import { Component, ChangeDetectorRef, OnInit } from '@angular/core';
import { NgClass, NgFor, NgIf } from '@angular/common';
import { PatientService } from '../../core/services/patient.service';
import { ToastService } from '../../core/services/toast.service';
import { AppointmentListDto } from '../../core/models/appointment.models';
import { extractErrorMessage } from '../../core/utils/error-utils';

@Component({
  selector: 'app-my-appointments',
  standalone: true,
  imports: [NgIf, NgFor, NgClass],
  templateUrl: './my-appointments.html',
  styleUrl: './my-appointments.scss',
})
export class MyAppointments implements OnInit {
  appointments: AppointmentListDto[] = [];
  loading = false;

  constructor(
    private readonly patientService: PatientService,
    private readonly toastService: ToastService,
    private readonly cdr: ChangeDetectorRef,
  ) {}

  ngOnInit(): void {
    this.loadAppointments();
  }

  private loadAppointments(): void {
    this.loading = true;
    this.patientService.getUpcomingAppointments().subscribe({
      next: (res) => {
        this.appointments = (res ?? []).filter(a => a.status !== 'Completed');
        this.loading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.loading = false;
        this.toastService.error(extractErrorMessage(err));
        this.cdr.detectChanges();
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
