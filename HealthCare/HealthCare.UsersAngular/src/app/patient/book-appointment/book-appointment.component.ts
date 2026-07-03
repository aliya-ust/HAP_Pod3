import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PatientSidebarComponent } from '../../shared/patient-sidebar/patient-sidebar.component';

@Component({
  selector: 'app-book-appointment',
  standalone: true,
  imports: [CommonModule, FormsModule, PatientSidebarComponent],
  templateUrl: './book-appointment.component.html',
  styleUrls: ['./book-appointment.component.css']
})
export class BookAppointmentComponent implements OnInit {

  minDate: string = '';
  selectedDate: string = '';

  selectedSpecialization: string = '';
  selectedDoctor: any = null;
  selectedSlot: string = '';
  noDoctorsMessage: string = '';
  hasSearched: boolean = false;
  showSuccessModal: boolean = false;
  showErrorModal: boolean = false;
  errorMessage: string = '';
  isBooking = false;

  doctors: any[] = [];
  timeSlots: string[] = [];

  specializations = [
    "GeneralMedicine", "Cardiology", "Dermatology", "Neurology",
    "Orthopedics", "Pediatrics", "Gynecology", "Psychiatry",
    "Ophthalmology", "ENT", "Urology", "Oncology",
    "Endocrinology", "Gastroenterology", "Pulmonology", "Nephrology"
  ];

  constructor(private readonly http: HttpClient, private readonly cdr: ChangeDetectorRef) { }

  ngOnInit() {
    this.minDate = new Date().toISOString().split('T')[0];
  }


  getDoctors() {

    if (!this.selectedDate || !this.selectedSpecialization) {
      this.hasSearched = false;

      this.doctors = [];
      this.timeSlots = [];
      this.selectedDoctor = null;
      this.selectedSlot = '';
      this.noDoctorsMessage = '';

      return;
    }

    // Reset immediately
    this.doctors = [];
    this.timeSlots = [];
    this.selectedDoctor = null;
    this.selectedSlot = '';
    this.noDoctorsMessage = '';

    this.hasSearched = true;

    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    this.http.get<any>(
      'https://localhost:7149/api/doctors/available',
      {
        headers,
        params: {
          specialisation: this.selectedSpecialization,
          date: this.selectedDate
        }
      }
    )
      .subscribe({
        next: (res) => {

          console.log('Doctor API response', res);

          this.doctors = res.doctors || [];

          if (this.doctors.length === 0) {
            this.noDoctorsMessage =
              res.message || 'Doctor is not available';
          }

          this.cdr.detectChanges();
        },
        error: (err) => {
          console.error(err);
        }
      });
  }



  onDoctorChange() {

    this.selectedSlot = '';
    this.timeSlots = [];

    if (!this.selectedDoctor || !this.selectedDate) return;

    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    this.http.get<string[]>(
      'https://localhost:7149/api/appointments/slots',
      {
        headers,
        params: {
          date: this.selectedDate,
          doctorId: this.selectedDoctor.doctorId
        }
      }
    ).subscribe(res => {
      console.log("Slots:", res);
      this.timeSlots = [...res];
      this.cdr.detectChanges();
    });
  }

  closeSuccessModal() {
    this.showSuccessModal = false;

    // Optional reset
    this.selectedDoctor = null;
    this.selectedSlot = '';
  }



  bookAppointment() {

    if (this.isBooking) return;

    if (!this.selectedDate ||
      !this.selectedSpecialization ||
      !this.selectedDoctor ||
      !this.selectedSlot) {

      alert("Please select all fields before booking");
      return;
    }

    this.isBooking = true;

    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    const body = {
      doctorId: this.selectedDoctor.doctorId,
      scheduledDate: this.selectedDate,
      timeSlot: this.selectedSlot
    };

    this.http.post(
      'https://localhost:7149/api/appointments/book',
      body,
      { headers }
    ).subscribe({
      next: () => {
        this.showSuccessModal = true;
        this.showErrorModal = false;
        this.isBooking = false;
      },
      error: (err) => {
        this.errorMessage =
          err.error?.message || "Unable to book appointment";

        this.showErrorModal = true;
        this.showSuccessModal = false;
        this.isBooking = false;
      }
    });
  }
}
