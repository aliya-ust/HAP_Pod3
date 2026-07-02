import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HealthRecord } from '../../cores/models/HealthRecord';
import { HealthRecordService } from '../../cores/services/health-record.service';

@Component({
  selector: 'app-health-record',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './health-record.html',
  styleUrls: ['./health-record.css']
})
export class HealthRecordComponent implements OnInit {

  healthRecords = signal<HealthRecord[]>([]);
  loading = signal(true);
  error = signal('');

  constructor(private healthRecordService: HealthRecordService) { }

  ngOnInit(): void {
    this.loadHealthRecords();
  }

  loadHealthRecords(): void {

    this.loading.set(true);
    this.error.set('');

    this.healthRecordService.getPatientHealthRecords().subscribe({

      next: (data) => {
        this.healthRecords.set(data);
        this.loading.set(false);
      },

      error: (err) => {
        console.error(err);
        this.error.set('Unable to load health records.');
        this.loading.set(false);
      }

    });
  }

}
