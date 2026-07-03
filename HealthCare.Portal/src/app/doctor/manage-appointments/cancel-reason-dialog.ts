import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { DialogRef } from '@angular/cdk/dialog';

@Component({
  selector: 'app-cancel-reason-dialog',
  standalone: true,
  imports: [ReactiveFormsModule],
  template: `
    <div class="dialog-overlay">
      <div class="dialog">
        <h3>Cancel Appointment</h3>
        <p>Please provide a reason for cancellation.</p>
        <form [formGroup]="form" (ngSubmit)="confirm()">
          <div class="form-group">
            <label for="reason">Cancellation Reason</label>
            <textarea
              id="reason"
              formControlName="reason"
              rows="3"
              maxlength="500"
              placeholder="Enter reason..."
            ></textarea>
            @if (form.get('reason')?.invalid && form.get('reason')?.touched) {
              <span class="field-error">Reason is required</span>
            }
          </div>
          <div class="dialog-actions">
            <button type="button" class="btn btn-secondary" (click)="cancel()">Go Back</button>
            <button type="submit" class="btn btn-danger" [disabled]="form.invalid">Cancel Appointment</button>
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
      min-width: 380px;
      max-width: 480px;
      box-shadow: 0 8px 32px rgba(0,0,0,0.15);
    }
    .dialog h3 { margin: 0 0 0.5rem; font-size: 1.1rem; }
    .dialog p { color: #666; font-size: 0.85rem; margin-bottom: 1rem; }
    .form-group {
      margin-bottom: 1rem;
    }
    .form-group label {
      display: block;
      margin-bottom: 0.35rem;
      font-size: 0.85rem;
      color: #555;
    }
    .form-group textarea {
      width: 100%;
      padding: 0.5rem 0.7rem;
      border: 1px solid #ccc;
      border-radius: 4px;
      font-size: 0.9rem;
      box-sizing: border-box;
      resize: vertical;
      font-family: inherit;
    }
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
    }
    .btn {
      padding: 0.5rem 1rem;
      border: none;
      border-radius: 4px;
      font-size: 0.9rem;
      cursor: pointer;
    }
    .btn:disabled { opacity: 0.6; cursor: not-allowed; }
    .btn-secondary { background: #e0e0e0; color: #333; }
    .btn-danger { background: #d93025; color: #fff; }
  `],
})
export class CancelReasonDialog {
  form: FormGroup;

  constructor(
    private readonly fb: FormBuilder,
    public dialogRef: DialogRef<string>,
  ) {
    this.form = this.fb.group({
      reason: ['', [Validators.required, Validators.maxLength(500)]],
    });
  }

  confirm(): void {
    if (this.form.invalid) return;
    this.dialogRef.close(this.form.value.reason);
  }

  cancel(): void {
    this.dialogRef.close();
  }
}
