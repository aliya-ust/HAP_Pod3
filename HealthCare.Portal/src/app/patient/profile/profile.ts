import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Dialog } from '@angular/cdk/dialog';
import { PatientService } from '../../core/services/patient.service';
import { ToastService } from '../../core/services/toast.service';
import { PatientListDto, UpdatePatientDto } from '../../core/models/patient.models';
import { extractErrorMessage } from '../../core/utils/error-utils';
import { EditProfileDialog } from './edit-profile-dialog';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [],
  templateUrl: './profile.html',
  styleUrl: './profile.scss',
})
export class Profile implements OnInit {
  profile: PatientListDto | null = null;

  constructor(
    private readonly patientService: PatientService,
    private readonly toastService: ToastService,
    private readonly dialog: Dialog,
    private readonly cdr: ChangeDetectorRef,
  ) {}

  ngOnInit(): void {
    this.loadProfile();
  }

  loadProfile(): void {
    this.patientService.getProfile().subscribe({
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

  openEditDialog(): void {
    if (!this.profile) return;

    const form: UpdatePatientDto = {
      fullName: this.profile.fullName,
      phoneNumber: this.profile.phoneNumber,
      email: this.profile.email,
      gender: this.profile.gender,
      insuranceId: this.profile.insuranceId ?? undefined,
    };

    const dialogRef = this.dialog.open(EditProfileDialog, { data: form });

    dialogRef.closed.subscribe((result) => {
      const dto = result as UpdatePatientDto | null;
      if (!dto) return;

      this.patientService.updateProfile(dto).subscribe({
        next: () => {
          this.loadProfile();
          this.toastService.success('Profile updated');
          this.cdr.detectChanges();
        },
        error: (err) => {
          this.toastService.error(extractErrorMessage(err));
          this.cdr.detectChanges();
        },
      });
    });
  }
}
