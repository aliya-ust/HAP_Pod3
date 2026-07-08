import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppointmentService } from '../../core/services/appointment.service';
import { DoctorService } from '../../core/services/doctor.service';

@Component({
  selector: 'app-book-appointment',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './book-appointment.html',
  styleUrl: './book-appointment.css'
})
export class BookAppointment {
  minDate = this.getTodayDate();

  selectedDate = '';
  selectedSpecialisation = '';
  selectedDoctorId: number | null = null;
  selectedTimeSlot = '';

  specialisations = [
    'Pediatrician',
    'Cardiologist',
    'Psychiatrist',
    'Orthopedic',
    'Dermatologist'
    
  ];

  constructor(
    public doctorService: DoctorService,
    private appointmentService: AppointmentService
  ) { }

  getTodayDate(): string {
    const today = new Date();
    const year = today.getFullYear();
    const month = String(today.getMonth() + 1).padStart(2, '0');
    const day = String(today.getDate()).padStart(2, '0');

    return `${year}-${month}-${day}`;
  }

  onDateOrSpecialisationChange(): void {
    this.selectedDoctorId = null;
    this.selectedTimeSlot = '';

    this.doctorService.availableDoctors.set([]);
    this.doctorService.availableSlots.set([]);

    if (!this.selectedDate || !this.selectedSpecialisation) {
      return;
    }

    this.doctorService.loadAvailableDoctors(
      this.selectedSpecialisation,
      this.selectedDate
    );
  }

  onDoctorChange(): void {
    this.selectedTimeSlot = '';
    this.doctorService.availableSlots.set([]);
    this.doctorService.slotsLoaded.set(false);

    if (!this.selectedDoctorId || !this.selectedDate) {
      return;
    }

    this.doctorService.loadAvailableSlots(
      Number(this.selectedDoctorId),
      this.selectedDate
    );
  }

  bookAppointment(): void {
    if (
      !this.selectedDate ||
      !this.selectedSpecialisation ||
      !this.selectedDoctorId ||
      !this.selectedTimeSlot
    ) {
      alert('Please fill all fields');
      return;
    }

    this.appointmentService.bookAppointment({
      doctorId: this.selectedDoctorId,
      scheduledDate: this.selectedDate,
      timeSlot: this.selectedTimeSlot
    }).subscribe({
      next: () => {
        alert('Appointment booked successfully');

        this.selectedDate = '';
        this.selectedSpecialisation = '';
        this.selectedDoctorId = null;
        this.selectedTimeSlot = '';

        this.doctorService.availableDoctors.set([]);
        this.doctorService.availableSlots.set([]);
      },
      error: (error) => {
        alert(error?.error?.message || 'Failed to book appointment');
      }
    });
  }
}
