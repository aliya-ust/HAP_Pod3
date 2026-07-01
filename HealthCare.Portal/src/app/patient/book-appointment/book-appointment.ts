import { Component, ChangeDetectorRef } from '@angular/core';
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
  doctors: DoctorListDto[] = [];
  selectedDoctor: DoctorListDto | null = null;
  timeSlots: string[] = [];
  selectedSlot = '';
  searching = false;
  booking = false;

  get todayDate(): string {
    return new Date().toISOString().split('T')[0];
  }

  constructor(
    private readonly patientService: PatientService,
    private readonly toastService: ToastService,
    private readonly cdr: ChangeDetectorRef,
  ) {}

  clearResults(): void {
    this.doctors = [];
    this.selectedDoctor = null;
    this.timeSlots = [];
    this.selectedSlot = '';
  }

  searchDoctors(): void {
    if (!this.selectedSpecialisation || !this.selectedDate) {
      this.toastService.warning('Please select a specialisation and date');
      return;
    }

    this.searching = true;
    this.doctors = [];
    this.selectedDoctor = null;
    this.timeSlots = [];
    this.selectedSlot = '';

    this.patientService.getAvailableDoctors(this.selectedSpecialisation, this.selectedDate).subscribe({
      next: (res) => {
        this.doctors = res ?? [];
        this.searching = false;
        if (this.doctors.length === 0) {
          this.toastService.info('No doctors available for this specialisation and date');
        }
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.searching = false;
        this.toastService.error(extractErrorMessage(err));
        this.cdr.detectChanges();
      },
    });
  }

  selectDoctor(doctor: DoctorListDto): void {
    this.selectedDoctor = doctor;
    this.selectedSlot = '';
    this.timeSlots = [];

    this.patientService.getAvailableSlots(doctor.doctorId, this.selectedDate).subscribe({
      next: (res) => {
        this.timeSlots = res ?? [];
        if (this.timeSlots.length === 0) {
          this.toastService.info('No available time slots for this doctor on the selected date');
        }
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.toastService.error(extractErrorMessage(err));
        this.cdr.detectChanges();
      },
    });
  }

  book(): void {
    if (!this.selectedDoctor || !this.selectedSlot) return;

    this.booking = true;
    this.patientService.bookAppointment({
      doctorId: this.selectedDoctor.doctorId,
      scheduledDate: this.selectedDate,
      timeSlot: this.selectedSlot,
    }).subscribe({
      next: () => {
        this.booking = false;
        this.toastService.success(`Appointment booked with ${this.selectedDoctor!.fullName} at ${this.selectedSlot}`);
        this.selectedDoctor = null;
        this.timeSlots = [];
        this.selectedSlot = '';
        this.doctors = [];
        this.selectedSpecialisation = '';
        this.selectedDate = '';
        this.cdr.detectChanges();
      },
      error: (err) => {
        this.booking = false;
        this.toastService.error(extractErrorMessage(err));
        this.cdr.detectChanges();
      },
    });
  }
}
