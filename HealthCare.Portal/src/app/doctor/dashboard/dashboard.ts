import { Component, ChangeDetectorRef, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ApiResponse } from '../../core/models/api-response';
import { AppointmentListDto } from '../../core/models/appointment.models';
import { ToastService } from '../../core/services/toast.service';
import { extractErrorMessage } from '../../core/utils/error-utils';

@Component({
  selector: 'app-doctor-dashboard',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class DoctorDashboard implements OnInit {
  todayAppointments: AppointmentListDto[] = [];
  upcomingCount = 0;
  pendingCount = 0;
  loading = true;
  todayStr!: string;

  constructor(
    private readonly http: HttpClient,
    private readonly toastService: ToastService,
    private readonly cdr: ChangeDetectorRef,
  ) {}

  ngOnInit(): void {
    const d = new Date();
    this.todayStr = `${d.getFullYear()}-${String(d.getMonth() + 1).padStart(2, '0')}-${String(d.getDate()).padStart(2, '0')}`;
    this.loadStats();
  }

  private loadStats(): void {
    const baseUrl = `${environment.apiUrl}/appointments`;

    this.http.get<ApiResponse<AppointmentListDto[]>>(`${baseUrl}/doctor/upcoming`).pipe(map(r => r.data)).subscribe({
      next: (appts) => {
        this.upcomingCount = appts.length;
        this.pendingCount = appts.filter(a => a.status === 'Pending').length;
        this.todayAppointments = appts.filter(a => a.scheduledDate === this.todayStr);
        this.loading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.loading = false;
        console.error(err);
        this.toastService.error(extractErrorMessage(err));
        this.cdr.detectChanges();
      },
    });
  }
}
