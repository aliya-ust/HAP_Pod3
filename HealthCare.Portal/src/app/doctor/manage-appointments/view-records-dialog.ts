import { Component, Inject } from '@angular/core';
import { DIALOG_DATA, DialogRef } from '@angular/cdk/dialog';
import { HealthRecordListDto } from '../../core/models/health-record.models';

@Component({
  selector: 'app-view-records-dialog',
  standalone: true,
  imports: [],
  template: `
    <div class="dialog-overlay">
      <div class="dialog" (click)="$event.stopPropagation()">
        <div class="dialog-header">
          <h3>Health Records — {{ patientName }}</h3>
          <button class="btn-close" (click)="close()">&times;</button>
        </div>
        <div class="dialog-body">
          @if (records.length === 0) {
            <div class="empty">No health records found.</div>
          }
          @for (r of records; track r.recordId) {
            <div class="record-card">
              <div class="record-meta">Visit: {{ r.visitDate }}</div>
              <div class="record-field"><label>Diagnosis</label><span>{{ r.diagnosis }}</span></div>
              <div class="record-field"><label>Prescription</label><span>{{ r.prescription }}</span></div>
              @if (r.notes) {
                <div class="record-field"><label>Notes</label><span>{{ r.notes }}</span></div>
              }
            </div>
          }
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
    background: #ffffff;

    width: 520px;
    max-width: 90vw;
    max-height: 80vh;

    display: flex;
    flex-direction: column;

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

  .dialog-header {
    display: flex;
    justify-content: space-between;
    align-items: center;

    padding: 1.5rem 1.5rem 1rem;

    border-bottom: 1px solid #edf2f7;
  }

  .dialog-header h3 {
    margin: 0;

    color: #003f88;
    font-size: 1.2rem;
    font-weight: 700;
  }

  .btn-close {
    background: transparent;
    border: none;

    width: 36px;
    height: 36px;

    border-radius: 50%;

    font-size: 1.4rem;
    color: #777;

    cursor: pointer;
    transition: all 0.3s ease;
  }

  .btn-close:hover {
    background: #f1f5f9;
    color: #003f88;
  }

  .dialog-body {
    flex: 1;
    overflow-y: auto;
    padding: 1.5rem;
  }

  .dialog-footer {
    padding: 1rem 1.5rem 1.5rem;
    display: flex;
    justify-content: flex-end;

    border-top: 1px solid #edf2f7;
  }

  .empty {
    text-align: center;
    padding: 2rem;

    color: #888;
    font-size: 0.95rem;
  }

  .record-card {
    background: #ffffff;

    border-radius: 16px;
    padding: 1rem 1.25rem;

    margin-bottom: 1rem;

    border-left: 5px solid #0077b6;

    box-shadow:
      0 8px 20px rgba(0, 31, 84, 0.10),
      0 3px 10px rgba(0, 31, 84, 0.06);

    transition: all 0.3s ease;
  }

  .record-card:hover {
    transform: translateY(-3px);

    box-shadow:
      0 16px 30px rgba(0, 31, 84, 0.15),
      0 6px 14px rgba(0, 31, 84, 0.10);
  }

  .record-meta {
    margin-bottom: 0.75rem;
    padding-bottom: 0.75rem;

    border-bottom: 1px solid #edf2f7;

    font-size: 0.85rem;
    font-weight: 600;
    color: #0077b6;
  }

  .record-field {
    display: flex;
    gap: 0.75rem;

    padding: 0.4rem 0;
    line-height: 1.5;
  }

  .record-field label {
    min-width: 95px;

    font-weight: 700;
    color: #003f88;
  }

  .record-field span {
    color: #444;
    flex: 1;
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

  .btn-primary {
    background: linear-gradient(
      135deg,
      #0077b6,
      #003f88
    );

    color: white;
  }

  .btn-primary:hover {
    transform: translateY(-2px);
    box-shadow: 0 6px 16px rgba(0, 119, 182, 0.35);
  }

  @media (max-width: 768px) {
    .record-field {
      flex-direction: column;
      gap: 0.25rem;
    }

    .record-field label {
      min-width: auto;
    }

    .dialog {
      width: 95vw;
    }
  }
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
