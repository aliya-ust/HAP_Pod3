import { Routes } from '@angular/router';

import { LoginComponent } from './features/auth/login/login';
import { RegisterComponent } from './features/auth/register/register';

import { PortalLayout } from './layout/portal-layout/portal-layout';
import { authGuard } from './core/guards/auth-guard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },

  {
    path: 'login',
    component: LoginComponent
  },

  {
    path: 'register',
    component: RegisterComponent
  },

  {
    path: 'patient',
    component: PortalLayout,
    canActivate: [authGuard],
    data: { role: 'PATIENT' },
    children: [
      {
        path: 'dashboard',
        loadComponent: () =>
          import('./patient/patient-dashboard/patient-dashboard')
            .then(c => c.PatientDashboard)
      },
      {
        path: 'profile',
        loadComponent: () =>
          import('./patient/my-profile/my-profile')
            .then(c => c.MyProfile)
      },
      {
        path: 'book-appointment',
        loadComponent: () =>
          import('./patient/book-appointment/book-appointment')
            .then(c => c.BookAppointment)
      },
      {
        path: 'appointments',
        loadComponent: () =>
          import('./patient/my-appointments/my-appointments')
            .then(c => c.MyAppointments)
      },
      {
        path: 'health-records',
        loadComponent: () =>
          import('./patient/health-records/health-records')
            .then(c => c.HealthRecords)
      },
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      }
    ]
  },

  {
    path: 'doctor',
    component: PortalLayout,
    canActivate: [authGuard],
    data: { role: 'DOCTOR' },
    children: [
      {
        path: 'dashboard',
        loadComponent: () =>
          import('./doctor/doctor-dashboard/doctor-dashboard')
            .then(c => c.DoctorDashboard)
      },
      {
        path: 'profile',
        loadComponent: () =>
          import('./doctor/doctor-profile/doctor-profile')
            .then(c => c.DoctorProfile)
      },
      {
        path: 'add-leaves',
        loadComponent: () =>
          import('./doctor/add-leaves/add-leaves')
            .then(c => c.AddLeaves)
      },
      {
        path: 'appointments',
        loadComponent: () =>
          import('./doctor/doctor-appointments/doctor-appointments')
            .then(c => c.DoctorAppointments)
      },
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      }
    ]
  },

  {
    path: '**',
    redirectTo: 'login'
  }
];
