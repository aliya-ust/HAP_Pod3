import { Component, ChangeDetectorRef, OnInit } from '@angular/core';

import { PatientService } from '../../core/services/patient.service';
import { ToastService } from '../../core/services/toast.service';
import { HealthRecordListDto } from '../../core/models/health-record.models';
import { extractErrorMessage } from '../../core/utils/error-utils';

@Component({
  selector: 'app-my-records',
  standalone: true,
  imports: [],
  templateUrl: './my-records.html',
  styleUrl: './my-records.scss',
})
export class MyRecords implements OnInit {
  records: HealthRecordListDto[] = [];
  loading = false;

  constructor(
    private readonly patientService: PatientService,
    private readonly toastService: ToastService,
    private readonly cdr: ChangeDetectorRef,
  ) {}

  ngOnInit(): void {
    this.loadRecords();
  }

  private loadRecords(): void {
    this.loading = true;
    this.patientService.getMyHealthRecords().subscribe({
      next: (res) => {
        this.records = res ?? [];
        this.loading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.loading = false;
        this.toastService.error(extractErrorMessage(err));
        this.cdr.detectChanges();
      },
    });
  }
}
