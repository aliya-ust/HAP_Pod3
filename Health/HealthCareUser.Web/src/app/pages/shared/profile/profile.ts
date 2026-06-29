import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PatientService } from '../../../cores/services/patient.services';
import { DoctorService } from '../../../cores/services/doctor.services';

import { PatientProfile } from '../../../cores/models/PatientProfile';
import { DoctorProfile } from '../../../cores/models/DoctorProfile';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './profile.html',
  styleUrls: ['./profile.css']
})
export class ProfileComponent implements OnInit {

  role = '';

  patient?: PatientProfile;

  doctor?: DoctorProfile;

  constructor(
    private patientService: PatientService,
    private doctorService: DoctorService
  ) { }

  ngOnInit(): void {

    this.role = localStorage.getItem('role') || '';

    if (this.role === 'Patient') {

      this.patientService.getProfile().subscribe({
        next: (data) => {
          this.patient = data;
        },
        error: (err) => {
          console.error(err);
        }
      });

    }

    if (this.role === 'Doctor') {

      this.doctorService.getProfile().subscribe({
        next: (data) => {
          this.doctor = data;
        },
        error: (err) => {
          console.error(err);
        }
      });

    }

  }

}
