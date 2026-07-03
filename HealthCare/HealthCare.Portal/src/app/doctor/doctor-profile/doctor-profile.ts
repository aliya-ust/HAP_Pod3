import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { DoctorService } from '../../core/services/doctor.service';

@Component({
  selector: 'app-doctor-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './doctor-profile.html',
  styleUrl: './doctor-profile.css'
})
export class DoctorProfile implements OnInit {
  constructor(public doctorService: DoctorService) { }

  ngOnInit(): void {
    this.doctorService.loadMyProfile();
  }
}
