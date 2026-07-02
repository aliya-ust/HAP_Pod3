import { Component, Inject } from '@angular/core';
import { NgIf } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DIALOG_DATA, DialogRef } from '@angular/cdk/dialog';
import { CreateHealthRecordDto } from '../../core/models/health-record.models';

export interface AddRecordData {
  appointmentId: number;
  patientId: number;
  visitDate: string;
}

@Component({
  selector: 'app-add-record-dialog',
  standalone: true,
  imports: [ReactiveFormsModule, NgIf],
  template: `
    <div class="dialog-overlay">
      <div class="dialog">
        <h3>Add Health Record</h3>
        <p class="dialog-subtitle">Visit Date: <strong>{{ data.visitDate }}</strong></p>
        <form [formGroup]="form" (ngSubmit)="submit()">
          <div class="form-group">
            <label for="diagnosis">Diagnosis</label>
            <input id="diagnosis" type="text" formControlName="diagnosis" maxlength="500" />
            <span class="field-error" *ngIf="form.get('diagnosis')?.invalid && form.get('diagnosis')?.touched">
              <span *ngIf="form.get('diagnosis')?.errors?.['required']">Diagnosis is required</span>
              <span *ngIf="form.get('diagnosis')?.errors?.['pattern']">Only letters and numbers allowed</span>
            </span>
          </div>
          <div class="form-group">
            <label for="prescription">Prescription</label>
            <input id="prescription" type="text" formControlName="prescription" maxlength="500" />
            <span class="field-error" *ngIf="form.get('prescription')?.invalid && form.get('prescription')?.touched">
              <span *ngIf="form.get('prescription')?.errors?.['required']">Prescription is required</span>
              <span *ngIf="form.get('prescription')?.errors?.['pattern']">Only letters and numbers allowed</span>
            </span>
          </div>
          <div class="form-group">
            <label for="notes">Notes (optional)</label>
            <textarea id="notes" formControlName="notes" rows="3" maxlength="1000"></textarea>
          </div>
          <div class="dialog-actions">
            <button type="button" class="btn btn-secondary" (click)="cancel()">Cancel</button>
            <button type="submit" class="btn btn-primary" [disabled]="form.invalid || submitting">
              {{ submitting ? 'Saving...' : 'Save Record' }}
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

    width: 440px;
    max-width: 90vw;

    padding: 1.75rem;
    border-radius: 20px;

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
    margin: 0 0 0.5rem;

    text-align: center;

    color: #003f88;
    font-size: 1.4rem;
    font-weight: 700;
  }

  .dialog-subtitle {
    text-align: center;

    color: #666;
    font-size: 0.9rem;

    margin-bottom: 1.5rem;
  }

  .form-group {
    margin-bottom: 1rem;
  }

  .form-group label {
    display: block;

    margin-bottom: 0.4rem;

    color: #555;
    font-size: 0.85rem;
    font-weight: 600;
  }

  .form-group input,
  .form-group textarea {
    width: 100%;

    padding: 0.75rem 1rem;

    background: #fafcff;

    border: 1px solid #d9e7f5;
    border-radius: 12px;

    font-size: 0.9rem;
    font-family: inherit;

    box-sizing: border-box;
    transition: all 0.3s ease;
  }

  .form-group textarea {
    resize: vertical;
    min-height: 90px;
  }

  .form-group input:focus,
  .form-group textarea:focus {
    outline: none;

    border-color: #90e0ef;
    box-shadow: 0 0 0 4px rgba(144, 224, 239, 0.25);

    transform: scale(1.02);
  }

  .field-error {
    display: block;

    margin-top: 0.3rem;

    color: #d93025;
    font-size: 0.8rem;
    font-weight: 500;
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
export class AddRecordDialog {
  form: FormGroup;
  submitting = false;

  constructor(
    @Inject(DIALOG_DATA) public data: AddRecordData,
    private readonly fb: FormBuilder,
    public dialogRef: DialogRef<CreateHealthRecordDto | null>,
  ) {
    this.form = this.fb.group({
      diagnosis: ['', [Validators.required, Validators.maxLength(500), Validators.pattern(/^[A-Za-z0-9\s]+$/)]],
      prescription: ['', [Validators.required, Validators.maxLength(500), Validators.pattern(/^[A-Za-z0-9\s]+$/)]],
      notes: ['', Validators.maxLength(1000)],
    });
  }

  submit(): void {
    if (this.form.invalid) return;
    this.submitting = true;
    const dto: CreateHealthRecordDto = {
      appointmentId: this.data.appointmentId,
      patientId: this.data.patientId,
      visitDate: this.data.visitDate,
      diagnosis: this.form.value.diagnosis,
      prescription: this.form.value.prescription,
      notes: this.form.value.notes || undefined,
    };
    this.dialogRef.close(dto);
  }

  cancel(): void {
    this.dialogRef.close(null);
  }
}
