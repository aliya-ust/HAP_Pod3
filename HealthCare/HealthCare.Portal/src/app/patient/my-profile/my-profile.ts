import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { PatientService } from '../../core/services/patient.service';
import { UpdatePatientProfileRequest } from '../../core/models/portal.models';

@Component({
  selector: 'app-my-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './my-profile.html',
  styleUrl: './my-profile.css'
})
export class MyProfile implements OnInit {
  showEditDialog = false;

  editProfile: UpdatePatientProfileRequest = {
    fullName: '',
    phoneNumber: '',
    gender: '',
    insuranceId: ''
  };

  constructor(public patientService: PatientService) { }

  ngOnInit(): void {
    this.patientService.loadProfile();
  }

  openEditDialog(): void {
    const patient = this.patientService.profile();

    if (!patient) {
      return;
    }

    this.editProfile = {
      fullName: patient.fullName,
      phoneNumber: patient.phoneNumber,
      gender: patient.gender,
      insuranceId: patient.insuranceId || ''
    };

    this.showEditDialog = true;
  }

  closeEditDialog(): void {
    this.showEditDialog = false;
  }

  saveProfile(): void {
    if (
      !this.editProfile.fullName ||
      !this.editProfile.phoneNumber ||
      !this.editProfile.gender
    ) {
      alert('Please fill Name, Phone and Gender');
      return;
    }

    this.patientService.updateProfile(this.editProfile).subscribe({
      next: () => {
        alert('Profile updated successfully');
        this.showEditDialog = false;
        this.patientService.loadProfile();
      },
      error: (error) => {
        alert(error?.error?.message || 'Failed to update profile');
      }
    });
  }
}

