import { Component, Inject } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { NgIf } from '@angular/common';
import { DIALOG_DATA, DialogRef } from '@angular/cdk/dialog';
import { UpdatePatientDto } from '../../core/models/patient.models';

@Component({
  selector: 'app-edit-profile-dialog',
  standalone: true,
  imports: [FormsModule, NgIf],
  template: `
    <div class="dialog-overlay">
      <div class="dialog">
        <h3>Edit Profile</h3>
        <form #formRef="ngForm" (ngSubmit)="save()">
          <div class="form-group">
            <label for="fullName">Full Name</label>
            <input id="fullName" name="fullName" type="text" [(ngModel)]="form.fullName" required pattern="[A-Za-z\s]+" #fullName="ngModel" />
            <div class="error" *ngIf="fullName.invalid && fullName.touched">
              <span *ngIf="fullName.errors?.['required']">Full name is required.</span>
              <span *ngIf="fullName.errors?.['pattern']">Full name must contain only alphabets.</span>
            </div>
          </div>
          <div class="form-group">
            <label for="email">Email</label>
            <input id="email" name="email" type="email" [(ngModel)]="form.email" required email #email="ngModel" />
            <div class="error" *ngIf="email.invalid && email.touched">
              <span *ngIf="email.errors?.['required']">Email is required.</span>
              <span *ngIf="email.errors?.['email']">Enter a valid email address.</span>
            </div>
          </div>
          <div class="form-group">
            <label for="phoneNumber">Phone Number</label>
            <input id="phoneNumber" name="phoneNumber" type="tel" [(ngModel)]="form.phoneNumber" required pattern="[6-9]\d{9}" #phone="ngModel" />
            <div class="error" *ngIf="phone.invalid && phone.touched">
              <span *ngIf="phone.errors?.['required']">Phone number is required.</span>
              <span *ngIf="phone.errors?.['pattern']">Phone must be 10 digits starting with 6-9.</span>
            </div>
          </div>
          <div class="form-group">
            <label for="gender">Gender</label>
            <select id="gender" name="gender" [(ngModel)]="form.gender" required #gender="ngModel">
              <option value="" disabled>Select</option>
              <option value="Male">Male</option>
              <option value="Female">Female</option>
              <option value="Other">Other</option>
            </select>
            <div class="error" *ngIf="gender.invalid && gender.touched">
              <span>Gender is required.</span>
            </div>
          </div>
          <div class="form-group">
            <label for="insuranceId">Insurance ID</label>
            <input id="insuranceId" name="insuranceId" type="text" [(ngModel)]="form.insuranceId" pattern="[A-Za-z0-9]+" #insurance="ngModel" />
            <div class="error" *ngIf="insurance.invalid && insurance.touched">
              <span *ngIf="insurance.errors?.['pattern']">Insurance ID must be alphanumeric.</span>
            </div>
          </div>
          <div class="dialog-actions">
            <button type="button" class="btn btn-secondary" (click)="cancel()">Cancel</button>
            <button type="submit" class="btn btn-primary" [disabled]="formRef.invalid || submitting">
              {{ submitting ? 'Saving...' : 'Save' }}
            </button>
          </div>
        </form>
      </div>
    </div>
  `,
  styles: [`
    .dialog-overlay {
      display: flex;
      align-items: center;
      justify-content: center;
    }
    .dialog {
      background: #fff;
      border-radius: 8px;
      padding: 1.5rem;
      width: 420px;
      max-width: 90vw;
      box-shadow: 0 8px 32px rgba(0,0,0,0.15);
    }
    .dialog h3 { margin: 0 0 1rem; font-size: 1.1rem; }
    .form-group { margin-bottom: 1rem; }
    .form-group label {
      display: block;
      margin-bottom: 0.35rem;
      font-size: 0.85rem;
      color: #555;
    }
    .form-group input, .form-group select {
      width: 100%;
      padding: 0.5rem 0.7rem;
      border: 1px solid #ccc;
      border-radius: 4px;
      font-size: 0.9rem;
      box-sizing: border-box;
    }
    .form-group input.ng-invalid.ng-touched,
    .form-group select.ng-invalid.ng-touched {
      border-color: #d32f2f;
    }
    .error {
      color: #d32f2f;
      font-size: 0.8rem;
      margin-top: 0.25rem;
    }
    .dialog-actions {
      display: flex;
      gap: 0.75rem;
      justify-content: flex-end;
      margin-top: 1.5rem;
    }
    .btn {
      padding: 0.5rem 1rem;
      border: none;
      border-radius: 4px;
      font-size: 0.9rem;
      cursor: pointer;
    }
    .btn:disabled { opacity: 0.6; cursor: not-allowed; }
    .btn-primary { background: #1a73e8; color: #fff; }
    .btn-secondary { background: #e0e0e0; color: #333; }
  `],
})
export class EditProfileDialog {
  form: UpdatePatientDto;
  submitting = false;

  constructor(
    @Inject(DIALOG_DATA) public data: UpdatePatientDto,
    public dialogRef: DialogRef<UpdatePatientDto | null>,
  ) {
    this.form = { ...data };
  }

  save(): void {
    this.submitting = true;
    this.dialogRef.close(this.form);
  }

  cancel(): void {
    this.dialogRef.close(null);
  }
}
