import { Component, Inject } from '@angular/core';
import { DIALOG_DATA, DialogRef } from '@angular/cdk/dialog';

export interface ConfirmLeaveData {
  dates: { date: string; reason: string }[];
}

@Component({
  selector: 'app-confirm-leave-dialog',
  standalone: true,
  imports: [],
  template: `
    <div class="dialog-overlay">
      <div class="dialog">
        <h3>Confirm Leave</h3>
        <p class="warning-text">
          Appointments on the following dates will be <strong>auto-cancelled</strong> if they exist.
        </p>
        <div class="date-list">
          @for (item of data.dates; track item.date) {
            <div class="date-item">
              <span class="date">{{ item.date }}</span>
              @if (item.reason) {
                <span class="reason">{{ item.reason }}</span>
              }
            </div>
          }
        </div>
        <div class="dialog-actions">
          <button class="btn btn-secondary" (click)="cancel()">Cancel</button>
          <button class="btn btn-primary" (click)="confirm()">Confirm</button>
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
    .dialog h3 { margin: 0 0 0.5rem; font-size: 1.1rem; }
    .warning-text {
      color: #d93025;
      font-size: 0.85rem;
      margin-bottom: 1rem;
      background: #fce8e6;
      padding: 0.75rem;
      border-radius: 4px;
    }
    .date-list {
      max-height: 240px;
      overflow-y: auto;
      margin-bottom: 1.25rem;
    }
    .date-item {
      display: flex;
      justify-content: space-between;
      padding: 0.5rem 0;
      border-bottom: 1px solid #eee;
      font-size: 0.9rem;
    }
    .date-item:last-child { border-bottom: none; }
    .date { font-weight: 600; color: #333; }
    .reason { color: #888; font-size: 0.8rem; }
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
    .btn-primary { background: #1a73e8; color: #fff; }
    .btn-secondary { background: #e0e0e0; color: #333; }
  `],
})
export class ConfirmLeaveDialog {
  constructor(
    @Inject(DIALOG_DATA) public data: ConfirmLeaveData,
    public dialogRef: DialogRef<boolean>,
  ) {}

  confirm(): void {
    this.dialogRef.close(true);
  }

  cancel(): void {
    this.dialogRef.close(false);
  }
}
