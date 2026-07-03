import { Component, Inject } from '@angular/core';
import { DIALOG_DATA, DialogRef } from '@angular/cdk/dialog';
import { CreateLeaveResultDto } from '../../core/models/doctor.models';

@Component({
  selector: 'app-leave-result-dialog',
  standalone: true,
  imports: [],
  template: `
    <div class="dialog-overlay">
      <div class="dialog">
        <h3>Leave Submitted</h3>

        @if (data.createdWithCancelledAppointments?.length) {
          <div class="section">
            <h4 class="cancelled-heading">&#9888; Appointments Cancelled</h4>
            <div class="date-list">
              @for (d of data.createdWithCancelledAppointments; track d) {
                <div class="date-item cancelled">{{ d }}</div>
              }
            </div>
          </div>
        }

        @if (data.skippedDates?.length) {
          <div class="section">
            <h4 class="skipped-heading">Skipped (already on leave)</h4>
            <div class="date-list">
              @for (d of data.skippedDates; track d) {
                <div class="date-item skipped">{{ d }}</div>
              }
            </div>
          </div>
        }

        @if (!data.skippedDates?.length && !data.createdWithCancelledAppointments?.length) {
          <div class="section">
            <p class="no-issues">All leaves added successfully with no conflicts.</p>
          </div>
        }

        <div class="dialog-actions">
          <button class="btn btn-primary" (click)="close()">OK</button>
        </div>
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
    .section { margin-bottom: 1rem; }
    .section:last-child { margin-bottom: 0; }
    h4 {
      margin: 0 0 0.5rem;
      font-size: 0.9rem;
      font-weight: 600;
    }
    .cancelled-heading { color: #d93025; }
    .skipped-heading { color: #f9ab00; }
    .date-list {
      max-height: 180px;
      overflow-y: auto;
    }
    .date-item {
      padding: 0.4rem 0.6rem;
      border-radius: 4px;
      font-size: 0.85rem;
      margin-bottom: 0.3rem;
    }
    .date-item.cancelled {
      background: #fce8e6;
      color: #d93025;
    }
    .date-item.skipped {
      background: #fef7e0;
      color: #e37400;
    }
    .no-issues {
      color: #188038;
      font-size: 0.9rem;
      background: #e6f4ea;
      padding: 0.75rem;
      border-radius: 4px;
    }
    .dialog-actions {
      display: flex;
      justify-content: flex-end;
      margin-top: 1rem;
    }
    .btn {
      padding: 0.5rem 1rem;
      border: none;
      border-radius: 4px;
      font-size: 0.9rem;
      cursor: pointer;
    }
    .btn-primary { background: #1a73e8; color: #fff; }
  `],
})
export class LeaveResultDialog {
  constructor(
    @Inject(DIALOG_DATA) public data: CreateLeaveResultDto,
    public dialogRef: DialogRef<void>,
  ) {}

  close(): void {
    this.dialogRef.close();
  }
}
