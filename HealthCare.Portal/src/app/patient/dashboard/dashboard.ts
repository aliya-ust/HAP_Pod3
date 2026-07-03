import { Component, ChangeDetectorRef, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { PatientService } from '../../core/services/patient.service';
import { ToastService } from '../../core/services/toast.service';
import { AppointmentListDto } from '../../core/models/appointment.models';
import { HealthRecordListDto } from '../../core/models/health-record.models';
import { extractErrorMessage } from '../../core/utils/error-utils';

@Component({
  selector: 'app-patient-dashboard',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard implements OnInit {
  upcomingAppointments: AppointmentListDto[] = [];
  latestRecords: HealthRecordListDto[] = [];
  loading = false;

  constructor(
    private readonly patientService: PatientService,
    private readonly toastService: ToastService,
    private readonly cdr: ChangeDetectorRef,
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  private loadData(): void {
    this.loading = true;
    this.patientService.getUpcomingAppointments().subscribe({
      next: (appts) => {
        this.upcomingAppointments = appts.slice(0, 3);
        this.loading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.loading = false;
        this.toastService.error(extractErrorMessage(err));
        this.cdr.detectChanges();
      },
    });

    this.patientService.getMyHealthRecords().subscribe({
      next: (records) => {
        this.latestRecords = records.slice(0, 3);
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.toastService.error(extractErrorMessage(err));
        this.cdr.detectChanges();
      },
    });
  }
}
