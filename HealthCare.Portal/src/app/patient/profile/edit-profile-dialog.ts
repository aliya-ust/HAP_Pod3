import { Component, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DIALOG_DATA, DialogRef } from '@angular/cdk/dialog';
import { UpdatePatientDto } from '../../core/models/patient.models';

@Component({
  selector: 'app-edit-profile-dialog',
  standalone: true,
  imports: [FormsModule],
  template: `
    <div class="dialog-overlay">
      <div class="dialog">
        <h3>Edit Profile</h3>
        <form #formRef="ngForm" (ngSubmit)="save()">
          <div class="form-group">
            <label for="fullName">Full Name</label>
            <input id="fullName" name="fullName" type="text" [(ngModel)]="form.fullName" required pattern="[A-Za-z ]+" #fullName="ngModel" />
            @if (fullName.invalid && fullName.touched) {
              <div class="error">
                @if (fullName.errors?.['required']) {<span>Full name is required.</span>}
                @if (fullName.errors?.['pattern']) {<span>Full name must contain only alphabets.</span>}
              </div>
            }
          </div>
          <div class="form-group">
            <label for="phoneNumber">Phone Number</label>
            <input id="phoneNumber" name="phoneNumber" type="tel" [(ngModel)]="form.phoneNumber" required pattern="[6-9][0-9]{9}" #phone="ngModel" />
            @if (phone.invalid && phone.touched) {
              <div class="error">
                @if (phone.errors?.['required']) {<span>Phone number is required.</span>}
                @if (phone.errors?.['pattern']) {<span>Phone must be 10 digits starting with 6-9.</span>}
              </div>
            }
          </div>
          <div class="form-group">
            <label for="gender">Gender</label>
            <select id="gender" name="gender" [(ngModel)]="form.gender" required #gender="ngModel">
              <option value="" disabled>Select</option>
              <option value="Male">Male</option>
              <option value="Female">Female</option>
              <option value="Other">Other</option>
            </select>
            @if (gender.invalid && gender.touched) {
              <div class="error">
                <span>Gender is required.</span>
              </div>
            }
          </div>
          <div class="form-group">
            <label for="insuranceId">Insurance ID</label>
            <input id="insuranceId" name="insuranceId" type="text" [(ngModel)]="form.insuranceId" pattern="[A-Za-z0-9]+" #insurance="ngModel" />
            @if (insurance.invalid && insurance.touched) {
              <div class="error">
                @if (insurance.errors?.['pattern']) {<span>Insurance ID must be alphanumeric.</span>}
              </div>
            }
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
    background: #ffffff;
    border-radius: 20px;
    padding: 1.75rem;

    width: 420px;
    max-width: 90vw;

    box-shadow:
      0 10px 25px rgba(0, 31, 84, 0.12),
      0 4px 12px rgba(0, 31, 84, 0.08);

    transition: all 0.3s ease;
  }

  .dialog:hover {
    transform: translateY(-4px);

    box-shadow:
      0 18px 35px rgba(0, 31, 84, 0.18),
      0 8px 18px rgba(0, 31, 84, 0.12);
  }

  .dialog h3 {
    margin: 0 0 1.5rem;
    text-align: center;

    color: #003f88;
    font-size: 1.4rem;
    font-weight: 700;
  }

  .form-group {
    margin-bottom: 1rem;
  }

  .form-group label {
    display: block;
    margin-bottom: 0.4rem;

    font-size: 0.85rem;
    font-weight: 600;

    color: #555;
  }

  .form-group input,
  .form-group select {
    width: 100%;
    padding: 0.75rem 1rem;

    background: #fafcff;

    border: 1px solid #d9e7f5;
    border-radius: 12px;

    font-size: 0.9rem;
    box-sizing: border-box;

    transition: all 0.3s ease;
  }

  .form-group input:focus,
  .form-group select:focus {
    outline: none;

    border-color: #90e0ef;
    box-shadow: 0 0 0 4px rgba(144, 224, 239, 0.25);

    transform: scale(1.02);
  }

  .form-group input.ng-invalid.ng-touched,
  .form-group select.ng-invalid.ng-touched {
    border-color: #d32f2f;
  }

  .error {
    color: #d32f2f;
    font-size: 0.8rem;
    margin-top: 0.3rem;
  }

  .dialog-actions {
    display: flex;
    justify-content: flex-end;
    gap: 0.75rem;

    margin-top: 1.5rem;
  }

  .btn {
    padding: 0.75rem 1.25rem;

    border: none;
    border-radius: 12px;

    font-size: 0.9rem;
    font-weight: 600;

    cursor: pointer;
    transition: all 0.3s ease;
  }

  .btn:disabled {
    opacity: 0.6;
    cursor: not-allowed;
  }

  .btn-primary {
    background: linear-gradient(
      135deg,
      #0077b6,
      #003f88
    );

    color: white;
  }

  .btn-primary:hover:not(:disabled) {
    transform: translateY(-2px);
    box-shadow: 0 6px 16px rgba(0, 119, 182, 0.35);
  }

  .btn-secondary {
    background: #e9eef5;
    color: #444;
  }

  .btn-secondary:hover {
    background: #dde6f0;
  }
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
