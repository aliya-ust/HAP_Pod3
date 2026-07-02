import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
import { PatientService } from '../../core/services/patient.service';
import { ToastService } from '../../core/services/toast.service';
import { DoctorListDto } from '../../core/models/doctor.models';
import { extractErrorMessage } from '../../core/utils/error-utils';

@Component({
  selector: 'app-book-appointment',
  standalone: true,
  imports: [FormsModule, NgFor, NgIf],
  templateUrl: './book-appointment.html',
  styleUrl: './book-appointment.scss',
})
export class BookAppointment {
  specialisations = [
    'Cardiology', 'Dentist', 'Dermatology', 'Neurology',
    'Orthopedics', 'Pediatrics', 'Psychiatry', 'Radiology',
    'General Medicine',
  ];

  selectedSpecialisation = '';
  selectedDate = '';
  doctors = signal<DoctorListDto[]>([]);
  selectedDoctor: DoctorListDto | null = null;
  timeSlots = signal<string[]>([]);
  selectedSlot = '';
  searching = signal(false);
  booking = signal(false);

  get todayDate(): string {
    return new Date().toISOString().split('T')[0];
  }

  constructor(
    private readonly patientService: PatientService,
    private readonly toastService: ToastService,
  ) {}

  clearResults(): void {
    this.doctors.set([]);
    this.selectedDoctor = null;
    this.timeSlots.set([]);
    this.selectedSlot = '';
  }

  searchDoctors(): void {
    if (!this.selectedSpecialisation || !this.selectedDate) {
      this.toastService.warning('Please select a specialisation and date');
      return;
    }

    this.searching.set(true);
    this.doctors.set([]);
    this.selectedDoctor = null;
    this.timeSlots.set([]);
    this.selectedSlot = '';

    this.patientService.getAvailableDoctors(this.selectedSpecialisation, this.selectedDate).subscribe({
      next: (res) => {
        this.doctors.set(res ?? []);
        this.searching.set(false);
        if (this.doctors().length === 0) {
          this.toastService.info('No doctors available for this specialisation and date');
        }
      },
      error: (err) => {
        this.searching.set(false);
        this.toastService.error(extractErrorMessage(err));
      },
    });
  }

  selectDoctor(doctor: DoctorListDto): void {
    this.selectedDoctor = doctor;
    this.selectedSlot = '';
    this.timeSlots.set([]);

    this.patientService.getAvailableSlots(doctor.doctorId, this.selectedDate).subscribe({
      next: (res) => {
        this.timeSlots.set(res ?? []);
        if (this.timeSlots().length === 0) {
          this.toastService.info('No available time slots for this doctor on the selected date');
        }
      },
      error: (err) => {
        this.toastService.error(extractErrorMessage(err));
      },
    });
  }

  book(): void {
    if (!this.selectedDoctor || !this.selectedSlot) return;

    this.booking.set(true);
    this.patientService.bookAppointment({
      doctorId: this.selectedDoctor.doctorId,
      scheduledDate: this.selectedDate,
      timeSlot: this.selectedSlot,
    }).subscribe({
      next: () => {
        this.booking.set(false);
        this.toastService.success(`Appointment booked with ${this.selectedDoctor!.fullName} at ${this.selectedSlot}`);
        this.selectedDoctor = null;
        this.timeSlots.set([]);
        this.selectedSlot = '';
        this.doctors.set([]);
        this.selectedSpecialisation = '';
        this.selectedDate = '';
      },
      error: (err) => {
        this.booking.set(false);
        this.toastService.error(extractErrorMessage(err));
      },
    });
  }
}
