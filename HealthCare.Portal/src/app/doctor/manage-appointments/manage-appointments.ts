import { Component, ChangeDetectorRef, OnInit } from '@angular/core';
import { Dialog } from '@angular/cdk/dialog';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DoctorService } from '../../core/services/doctor.service';
import { ToastService } from '../../core/services/toast.service';
import { AppointmentListDto } from '../../core/models/appointment.models';
import { CreateHealthRecordDto } from '../../core/models/health-record.models';
import { CancelReasonDialog } from './cancel-reason-dialog';
import { ViewRecordsDialog } from './view-records-dialog';
import { AddRecordDialog } from './add-record-dialog';
import { extractErrorMessage } from '../../core/utils/error-utils';

@Component({
  selector: 'app-manage-appointments',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './manage-appointments.html',
  styleUrl: './manage-appointments.scss',
})
export class ManageAppointments implements OnInit {
  appointments: AppointmentListDto[] = [];
  filteredAppointments: AppointmentListDto[] = [];
  pagedAppointments: AppointmentListDto[] = [];
  statusFilter = 'All';
  loading = false;
  pageSize = 5;
  currentPage = 1;

  get totalPages(): number {
    return Math.ceil(this.filteredAppointments.length / this.pageSize) || 1;
  }

  constructor(
    private readonly doctorService: DoctorService,
    private readonly toastService: ToastService,
    private readonly dialog: Dialog,
    private readonly cdr: ChangeDetectorRef,
  ) {}

  ngOnInit(): void {
    this.loadAppointments();
  }

  private loadAppointments(): void {
    this.loading = true;
    this.doctorService.getUpcomingAppointments().subscribe({
      next: (res) => {
        this.appointments = res.filter(a => a.status !== 'Completed');
        this.applyFilter();
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

  applyFilter(): void {
    this.filteredAppointments = this.statusFilter === 'All'
      ? this.appointments
      : this.appointments.filter(a => a.status === this.statusFilter);
    this.currentPage = 1;
    this.applyPaging();
  }

  applyPaging(): void {
    const start = (this.currentPage - 1) * this.pageSize;
    this.pagedAppointments = this.filteredAppointments.slice(start, start + this.pageSize);
  }

  goToPage(page: number): void {
    if (page < 1 || page > this.totalPages) return;
    this.currentPage = page;
    this.applyPaging();
  }

  confirmAppointment(id: number): void {
    this.doctorService.updateAppointmentStatus(id, { status: 'Confirmed' }).subscribe({
      next: () => {
        this.toastService.success('Appointment confirmed');
        this.loadAppointments();
      },
      error: (err) => {
        console.error(err);
        this.toastService.error(extractErrorMessage(err));
      },
    });
  }

  cancelAppointment(id: number): void {
    const dialogRef = this.dialog.open<string>(CancelReasonDialog, { width: '440px' });
    dialogRef.closed.subscribe(reason => {
      if (!reason) return;
      this.doctorService.updateAppointmentStatus(id, { status: 'Cancelled', cancellationReason: reason }).subscribe({
        next: () => {
          this.toastService.success('Appointment cancelled');
          this.loadAppointments();
        },
        error: (err) => {
          console.error(err);
          this.toastService.error(extractErrorMessage(err));
        },
      });
    });
  }

  viewHealthRecords(appointment: AppointmentListDto): void {
    this.doctorService.getHealthRecordsByPatient(appointment.patientId).subscribe({
      next: (records) => {
        this.dialog.open(ViewRecordsDialog, {
          data: { records, patientName: appointment.patientName },
        });
      },
      error: (err) => {
        console.error(err);
        this.toastService.error(extractErrorMessage(err));
      },
    });
  }

  addHealthRecord(appointment: AppointmentListDto): void {
    const dialogRef = this.dialog.open(AddRecordDialog, {
      data: { appointmentId: appointment.appointmentId, patientId: appointment.patientId, visitDate: appointment.scheduledDate },
    });
    dialogRef.closed.subscribe((result: unknown) => {
      const dto = result as CreateHealthRecordDto | null;
      if (!dto) return;
      this.doctorService.createHealthRecord(dto).subscribe({
        next: () => {
          this.toastService.success('Health record created');
          this.loadAppointments();
        },
        error: (err) => {
          console.error(err);
          this.toastService.error(extractErrorMessage(err));
        },
      });
    });
  }
}
