import { Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout/layout';
import { AuthGuard } from './cores/guards/auth-guard';
import { RoleGuard } from './cores/guards/role-guard';

export const routes: Routes = [

  // Login
  {
    path: '',
    loadComponent: () =>
      import('./Login/all-login/all-login').then(m => m.AllLoginComponent)
  },

  // Register
  {
    path: 'register',
    loadComponent: () =>
      import('./Login/register/register').then(m => m.RegisterComponent)
  },

  // Common Layout
  {
    path: '',
    component: LayoutComponent,

    children: [

      {
        path: 'dashboard',
        loadComponent: () =>
          import('./pages/shared/dashboard/dashboard')
            .then(c => c.DashboardComponent),
         canActivate: [AuthGuard]
      },

      {
        path: 'profile',
        loadComponent: () =>
          import('./pages/shared/profile/profile')
            .then(c => c.ProfileComponent),
        canActivate: [AuthGuard]
      },

      {
        path: 'appointments',
        loadComponent: () =>
          import('./pages/shared/appointments/appointments')
            .then(c => c.AppointmentsComponent),
        canActivate: [AuthGuard]
      },

      {
        path: 'book-appointment',
        loadComponent: () =>
          import('./pages/book-appointment/book-appointment')
            .then(c => c.BookAppointmentComponent),

        canActivate: [AuthGuard, RoleGuard],
        data: { role: 'Patient' }

      },

      {
        path: 'health-record',
        loadComponent: () =>
          import('./pages/health-record/health-record')
            .then(c => c.HealthRecordComponent),
        canActivate: [AuthGuard, RoleGuard],
        data: { role: 'Patient' }
      },

      {
        path: 'leave',
        loadComponent: () =>
          import('./pages/doctor-leave/doctor-leave')
            .then(c => c.DoctorLeaveComponent),

        canActivate: [AuthGuard, RoleGuard],
        data: { role: 'Doctor' } 

      }

    ]
  },

  {
    path: '**',
    redirectTo: 'login',
    pathMatch: 'full'

  }

];
