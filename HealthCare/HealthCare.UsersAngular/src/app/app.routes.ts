import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { PatientRegisterComponent } from './auth/register-patient/register-patient.component';
import { PatientDashboardComponent } from './patient-dashboard/patient-dashboard.component';
import { DoctorDashboardComponent } from './doctor-dashboard/doctor-dashboard.component';
import { ProfileComponent } from './patient/profile/profile.component';
import { BookAppointmentComponent } from './patient/book-appointment/book-appointment.component';
import { MyAppointmentsComponent } from './patient/patient-appointments/patient-appointments.component';
import { MedicalHistoryComponent } from './patient/medical-history/medical-history.component'
import { DoctorProfileComponent } from './doctor/doctor-profile/doctor-profile.component';
import { DoctorAppointmentsComponent } from './doctor/doctor-appointments/doctor-appointments.component';
import { DoctorLeavesComponent } from './doctor/doctor-leaves/doctor-leaves.component';
import { authGuard } from './guards/auth.guard';
import { roleGuard } from './guards/role.guard';

export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register-patient', component: PatientRegisterComponent },
  {
    path: 'patient-dashboard',
    component: PatientDashboardComponent,
    canActivate: [authGuard, roleGuard],
    data: { roles: ['Patient'] }
  },
  {
    path: 'patient-profile',
    component: ProfileComponent,
    canActivate: [authGuard, roleGuard],
    data: { roles: ['Patient'] }
  },
  {
    path: 'book-appointment',
    component: BookAppointmentComponent,
    canActivate: [authGuard, roleGuard],
    data: { roles: ['Patient'] }
  },
  {
    path: 'my-appointments',
    component: MyAppointmentsComponent,
    canActivate: [authGuard, roleGuard],
    data: { roles: ['Patient'] }
  },
  {
    path: 'medical-history',
    component: MedicalHistoryComponent,
    canActivate: [authGuard, roleGuard],
    data: { roles: ['Patient'] }
  },

  {
    path: 'doctor-dashboard',
    component: DoctorDashboardComponent,
    canActivate: [authGuard, roleGuard],
    data: { roles: ['Doctor'] }
  },
  {
    path: 'doctor-profile',
    component: DoctorProfileComponent,
    canActivate: [authGuard, roleGuard],
    data: { roles: ['Doctor'] }
  },
  {
    path: 'doctor-appointments',
    component: DoctorAppointmentsComponent,
    canActivate: [authGuard, roleGuard],
    data: { roles: ['Doctor'] }
  },
  {
    path: 'doctor-leaves',
    component: DoctorLeavesComponent,
    canActivate: [authGuard, roleGuard],
    data: { roles: ['Doctor'] }
  },
  
{
    path: '**',
    redirectTo: ''
  }

  
];

