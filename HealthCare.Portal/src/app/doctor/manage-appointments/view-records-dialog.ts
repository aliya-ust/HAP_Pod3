import { Component, Inject } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { DIALOG_DATA, DialogRef } from '@angular/cdk/dialog';
import { HealthRecordListDto } from '../../core/models/health-record.models';

@Component({
  selector: 'app-view-records-dialog',
  standalone: true,
  imports: [NgIf, NgFor],
  template: `
    <div class="dialog-overlay">
      <div class="dialog" (click)="$event.stopPropagation()">
        <div class="dialog-header">
          <h3>Health Records — {{ patientName }}</h3>
          <button class="btn-close" (click)="close()">&times;</button>
        </div>
        <div class="dialog-body">
          <div *ngIf="records.length === 0" class="empty">No health records found.</div>
          <div *ngFor="let r of records" class="record-card">
            <div class="record-meta">Visit: {{ r.visitDate }}</div>
            <div class="record-field"><label>Diagnosis</label><span>{{ r.diagnosis }}</span></div>
            <div class="record-field"><label>Prescription</label><span>{{ r.prescription }}</span></div>
            <div class="record-field" *ngIf="r.notes"><label>Notes</label><span>{{ r.notes }}</span></div>
          </div>
        </div>
        <div class="dialog-footer">
          <button class="btn btn-primary" (click)="close()">Close</button>
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
      display: flex;
      flex-direction: column;
      max-height: 80vh;
      width: 520px;
      box-shadow: 0 8px 32px rgba(0,0,0,0.15);
    }
    .dialog-header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      padding: 1.25rem 1.5rem 0;
    }
    .dialog-header h3 { margin: 0; font-size: 1.05rem; }
    .btn-close {
      background: none;
      border: none;
      font-size: 1.5rem;
      cursor: pointer;
      color: #888;
      padding: 0;
      line-height: 1;
    }
    .dialog-body {
      padding: 1rem 1.5rem;
      overflow-y: auto;
      flex: 1;
    }
    .dialog-footer {
      padding: 0.75rem 1.5rem 1.25rem;
      display: flex;
      justify-content: flex-end;
    }
    .empty { color: #999; text-align: center; padding: 2rem; font-size: 0.9rem; }
    .record-card {
      background: #f9f9f9;
      border-radius: 6px;
      padding: 1rem;
      margin-bottom: 0.75rem;
    }
    .record-meta {
      font-size: 0.8rem;
      color: #777;
      margin-bottom: 0.5rem;
    }
    .record-field {
      display: flex;
      gap: 0.5rem;
      padding: 0.3rem 0;
      font-size: 0.9rem;
    }
    .record-field label {
      font-weight: 600;
      color: #555;
      min-width: 90px;
    }
    .record-field span { color: #333; }
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
export class ViewRecordsDialog {
  records: HealthRecordListDto[];
  patientName: string;

  constructor(
    @Inject(DIALOG_DATA) data: { records: HealthRecordListDto[]; patientName: string },
    public dialogRef: DialogRef<void>,
  ) {
    this.records = data.records;
    this.patientName = data.patientName;
  }

  close(): void {
    this.dialogRef.close();
  }
}
