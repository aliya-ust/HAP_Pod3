import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppointmentService } from '../../cores/services/appointments.services';
import { DoctorDropdownDto, CreateAppointmentDto } from '../../cores/models/Appointment';

@Component({
  selector: 'app-book-appointment',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './book-appointment.html',
  styleUrls: ['./book-appointment.css']
})
export class BookAppointmentComponent {

  date = signal('');
  specialization = signal('');

  specializations: string[] = [
    "GeneralMedicine", "Cardiology", "Dermatology", "Neurology",
    "Orthopedics", "Pediatrics", "Gynecology", "Psychiatry",
    "Ophthalmology", "ENT", "Urology", "Oncology",
    "Endocrinology", "Gastroenterology", "Pulmonology", "Nephrology"
  ];

  doctors = signal<DoctorDropdownDto[]>([]);
  timeSlots = signal<string[]>([]);

  selectedDoctorId = signal<number | null>(null);
  selectedSlot = signal('');

  message = signal('');
  isLoadingDoctors = signal(false);
  isLoadingSlots = signal(false);

  constructor(private readonly appointmentService: AppointmentService) { }

  get minDate(): string {
    return new Date().toISOString().split('T')[0];
  }

  // Trigger when date OR specialization changes
  onDateOrSpecializationChange() {
    this.doctors.set([]);
    this.selectedDoctorId.set(null);
    this.timeSlots.set([]);
    this.selectedSlot.set('');
    this.message.set('');

    if (this.date() && this.specialization()) {
      this.loadDoctors();
    }
  }

  // UPDATED: Sends date to backend (important for leave filtering)
  loadDoctors() {
    this.isLoadingDoctors.set(true);

    this.appointmentService
      .getAvailableDoctors(this.date(), this.specialization())
      .subscribe({
        next: (res) => {
          this.doctors.set(res);
          this.isLoadingDoctors.set(false);
        },
        error: () => {
          this.message.set("No Doctors Available");
          this.isLoadingDoctors.set(false);
        }
      });
  }

  // Doctor selected → load slots
  onDoctorChange() {
    this.timeSlots.set([]);
    this.selectedSlot.set('');
    this.message.set('');

    if (this.selectedDoctorId()) {
      this.isLoadingSlots.set(true);

      this.appointmentService
        .getAvailableSlots(this.selectedDoctorId()!, this.date())
        .subscribe({
          next: (res) => {
            this.timeSlots.set(res);
            this.isLoadingSlots.set(false);
          },
          error: () => {
            this.message.set("Failed to load time slots");
            this.isLoadingSlots.set(false);
          }
        });
    }
  }

  // Booking
  bookAppointment() {

    if (!this.date() || !this.selectedDoctorId() || !this.selectedSlot()) {
      this.message.set("Please fill all fields");
      return;
    }

    const dto: CreateAppointmentDto = {
      doctorId: this.selectedDoctorId()!,
      scheduledDate: this.date(),
      timeSlot: this.selectedSlot()
    };

    this.appointmentService.bookAppointment(dto)
      .subscribe({
        next: () => {
          this.message.set("Appointment booked successfully!");
          this.reset();
        },
        error: (err) => {
          // show backend validation message (doctor on leave, inactive, etc.)
          this.message.set(err?.error?.message || "Failed to book appointment");
        }
      });
  }

  // Reset everything
  reset() {
    this.date.set('');
    this.specialization.set('');
    this.doctors.set([]);
    this.timeSlots.set([]);
    this.selectedDoctorId.set(null);
    this.selectedSlot.set('');
  }
}
