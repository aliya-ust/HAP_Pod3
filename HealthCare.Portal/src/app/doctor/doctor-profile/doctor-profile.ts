import { Component, ChangeDetectorRef, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
import { Dialog } from '@angular/cdk/dialog';
import { DoctorService } from '../../core/services/doctor.service';
import { ToastService } from '../../core/services/toast.service';
import { DoctorListDto } from '../../core/models/doctor.models';
import { extractErrorMessage } from '../../core/utils/error-utils';
import { ConfirmLeaveDialog } from './confirm-leave-dialog';
import { LeaveResultDialog } from './leave-result-dialog';

@Component({
  selector: 'app-doctor-profile',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf, NgFor],
  templateUrl: './doctor-profile.html',
  styleUrl: './doctor-profile.scss',
})
export class DoctorProfile implements OnInit {
  profile: DoctorListDto | null = null;
  leaveForm!: FormGroup;
  loading = false;
  submittingLeaves = false;

  constructor(
    private readonly doctorService: DoctorService,
    private readonly toastService: ToastService,
    private readonly fb: FormBuilder,
    private readonly dialog: Dialog,
    private readonly cdr: ChangeDetectorRef,
  ) {}

  ngOnInit(): void {
    this.leaveForm = this.fb.group({
      leaveDates: this.fb.array([]),
    });
    this.loadProfile();
  }

  get leaveDates(): FormArray {
    return this.leaveForm.get('leaveDates') as FormArray;
  }

  today(): string {
    return new Date().toISOString().split('T')[0];
  }

  addLeaveDate(): void {
    const group = this.fb.group({
      date: ['', [Validators.required, this.futureDateValidator()]],
      reason: ['', Validators.maxLength(500)],
    });
    this.leaveDates.push(group);
  }

  removeLeaveDate(index: number): void {
    this.leaveDates.removeAt(index);
  }

  private futureDateValidator() {
    return (control: { value: string }) => {
      if (!control.value) return null;
      const selected = new Date(control.value);
      const today = new Date();
      today.setHours(0, 0, 0, 0);
      return selected >= today ? null : { pastDate: true };
    };
  }

  private loadProfile(): void {
    this.doctorService.getProfile().subscribe({
      next: (res) => {
        this.profile = res;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.toastService.error(extractErrorMessage(err));
        this.cdr.detectChanges();
      },
    });
  }

  submitLeaves(): void {
    if (this.leaveForm.invalid) return;

    const leaves = this.leaveDates.value.map((l: { date: string; reason: string }) => ({
      leaveDate: l.date,
      reason: l.reason || undefined,
    }));

    const dialogRef = this.dialog.open(ConfirmLeaveDialog, {
      data: {
        dates: this.leaveDates.value.map((l: { date: string; reason: string }) => ({
          date: l.date,
          reason: l.reason || '',
        })),
      },
    });

    dialogRef.closed.subscribe((confirmed) => {
      if (!confirmed) return;

      this.submittingLeaves = true;
      this.doctorService.addLeaves(leaves).subscribe({
        next: (result) => {
          this.submittingLeaves = false;

          if (result.skippedDates?.length || result.createdWithCancelledAppointments?.length) {
            this.dialog.open(LeaveResultDialog, { data: result });
          } else {
            this.toastService.success('Leaves added successfully');
          }

          this.leaveForm.reset();
          while (this.leaveDates.length) this.leaveDates.removeAt(0);
        },
        error: (err) => {
          this.submittingLeaves = false;
          this.toastService.error(extractErrorMessage(err));
        },
      });
    });
  }
}
