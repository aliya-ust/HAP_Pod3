import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { HealthRecordService } from '../../core/services/health-record.service';
import { HealthRecordResponse } from '../../core/models/portal.models';

@Component({
  selector: 'app-health-records',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './health-records.html',
  styleUrl: './health-records.css'
})
export class HealthRecords implements OnInit {
  records: HealthRecordResponse[] = [];
  isLoading = false;
  errorMessage = '';

  constructor(private healthRecordService: HealthRecordService) { }

  ngOnInit(): void {
    this.loadRecords();
  }

  loadRecords(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.healthRecordService.getMyRecords().subscribe({
      next: (res) => {
        this.records = res || [];
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Failed to load health records:', error);
        this.records = [];
        this.errorMessage = 'Failed to load health records.';
        this.isLoading = false;
      }
    });
  }
}
