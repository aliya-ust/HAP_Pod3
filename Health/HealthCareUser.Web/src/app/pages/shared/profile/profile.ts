import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { PatientService } from '../../../cores/services/patient.services';
import { DoctorService } from '../../../cores/services/doctor.services';

import { PatientProfile } from '../../../cores/models/PatientProfile';
import { DoctorProfile } from '../../../cores/models/DoctorProfile';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './profile.html',
  styleUrls: ['./profile.css']
})
export class ProfileComponent implements OnInit {

  role = signal('');
  patient = signal<PatientProfile | null>(null);
  doctor = signal<DoctorProfile | null>(null);

  // ✅ dialog control
  isEditOpen = signal(false);

  // ✅ editable data (no email & DOB)
  editData: any = {
    fullName: '',
    phoneNumber: '',
    gender: '',
    insuranceId: ''
  };

  constructor(
    private patientService: PatientService,
    private doctorService: DoctorService
  ) { }

  ngOnInit(): void {

    const roleValue = localStorage.getItem('role') || '';
    this.role.set(roleValue);

    if (roleValue === 'Patient') {
      this.loadPatient();
    }

    if (roleValue === 'Doctor') {
      this.doctorService.getProfile().subscribe({
        next: (data) => this.doctor.set(data),
        error: (err) => console.error(err)
      });
    }
  }

  // ✅ load profile
  loadPatient() {
    this.patientService.getProfile().subscribe({
      next: (data) => this.patient.set(data),
      error: (err) => console.error(err)
    });
  }

  // ✅ open dialog
  openEdit() {
    const p = this.patient();

    if (p) {
      this.editData = {
        fullName: p.fullName,
        phoneNumber: p.phoneNumber,
        gender: p.gender,
        insuranceId: p.insuranceId
      };
    }

    this.isEditOpen.set(true);
  }

  // ✅ close dialog
  closeEdit() {
    this.isEditOpen.set(false);
  }

  updateProfile() {
    if (!this.editData.fullName || this.editData.fullName.trim().length < 3) {
      alert('Invalid name');
      return;
    }

    // Normalize insurance (important for your filtering logic!)
    if (!this.editData.insuranceId || this.editData.insuranceId.trim() === '') {
      this.editData.insuranceId = null;
    }

    this.patientService.updateProfile(this.editData).subscribe({
      next: () => {
        alert('Profile updated successfully');
        this.loadPatient();
        this.closeEdit();
      },
      error: (err) => {
        console.error(err);
        alert('Update failed');
      }
    });
  }
}
