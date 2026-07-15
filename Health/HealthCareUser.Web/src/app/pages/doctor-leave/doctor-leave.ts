import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { DoctorLeaveService } from '../../cores/services/doctor-leave.service';
import { CreateLeave } from '../../cores/models/doctor-leave';

@Component({
  selector: 'app-doctor-leave',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './doctor-leave.html',
  styleUrls: ['./doctor-leave.css']
})
export class DoctorLeaveComponent {

  selectedDate = signal('');
  reason = signal('');

  leaveDates = signal<string[]>([]);

  successMessage = signal('');
  errorMessage = signal('');

  constructor(private readonly leaveService: DoctorLeaveService) { }

  addLeaveDate(): void {

    this.successMessage.set('');
    this.errorMessage.set('');

    if (!this.selectedDate()) {
      alert('Please select a leave date.');
      return;
    }

    if (this.leaveDates().includes(this.selectedDate())) {
      alert('This date has already been added.');
      return;
    }

    const updated = [...this.leaveDates(), this.selectedDate()]
      .sort((a, b) => a.localeCompare(b));
    this.leaveDates.set(updated);

    this.selectedDate.set('');
  }

  removeLeaveDate(index: number): void {

    const updated = [...this.leaveDates()];
    updated.splice(index, 1);

    this.leaveDates.set(updated);
  }

  submitLeaves(): void {

    this.successMessage.set('');
    this.errorMessage.set('');

    if (this.leaveDates().length === 0) {
      alert('Please add at least one leave date.');
      return;
    }

    const leaves: CreateLeave[] = this.leaveDates().map(date => ({
      leaveDate: date,
      reason: this.reason()
    }));

    this.leaveService.createLeaves(leaves).subscribe({

      next: (res) => {

        let message = 'Leaves added successfully.';

        if (res.skippedDates.length > 0) {
          message += ` Skipped: ${res.skippedDates.join(', ')}`;
        }

        if (res.createdWithCancelledAppointments.length > 0) {
          message += ` Appointments cancelled on: ${res.createdWithCancelledAppointments.join(', ')}`;
        }

        this.successMessage.set(message);

        this.leaveDates.set([]);
        this.reason.set('');
      },

      error: () => {
        this.errorMessage.set('Unable to add leaves.');
      }

    });
  }

}
