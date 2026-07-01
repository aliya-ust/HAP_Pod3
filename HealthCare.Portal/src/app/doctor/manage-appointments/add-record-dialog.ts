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
      background: #fff;
      border-radius: 8px;
      padding: 1.5rem;
      width: 440px;
      max-width: 90vw;
      box-shadow: 0 8px 32px rgba(0,0,0,0.15);
    }
    .dialog h3 { margin: 0 0 0.25rem; font-size: 1.1rem; }
    .dialog-subtitle { font-size: 0.85rem; color: #555; margin: 0 0 1rem; }
    .form-group { margin-bottom: 1rem; }
    .form-group label {
      display: block;
      margin-bottom: 0.35rem;
      font-size: 0.85rem;
      color: #555;
    }
    .form-group input, .form-group textarea {
      width: 100%;
      padding: 0.5rem 0.7rem;
      border: 1px solid #ccc;
      border-radius: 4px;
      font-size: 0.9rem;
      box-sizing: border-box;
      font-family: inherit;
    }
    .form-group textarea { resize: vertical; }
    .field-error {
      display: block;
      color: #d93025;
      font-size: 0.75rem;
      margin-top: 0.25rem;
    }
    .dialog-actions {
      display: flex;
      gap: 0.75rem;
      justify-content: flex-end;
      margin-top: 0.5rem;
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
