import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DoctorService } from '../../core/services/doctor.service';

@Component({
  selector: 'app-add-leaves',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-leaves.html',
  styleUrl: './add-leaves.css'
})
export class AddLeaves {
  minDate = this.getTodayDate();
  leaveDate = '';
  reason = '';

  constructor(private doctorService: DoctorService) { }

  getTodayDate(): string {
    const today = new Date();
    return today.toISOString().split('T')[0];
  }

  addLeave(): void {
    if (!this.leaveDate) {
      alert('Please select leave date');
      return;
    }

    this.doctorService.addLeaves([
      {
        leaveDate: this.leaveDate,
        reason: this.reason
      }
    ]).subscribe({
      next: () => {
        alert('Leave added successfully');
        this.leaveDate = '';
        this.reason = '';
      },
      error: (error) => {
        alert(error?.error?.message || 'Failed to add leave');
      } 
    });
  }
}
