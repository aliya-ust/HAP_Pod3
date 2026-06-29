import { Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout/layout';

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
            .then(c => c.DashboardComponent)
      },

      {
        path: 'profile',
        loadComponent: () =>
          import('./pages/shared/profile/profile')
            .then(c => c.ProfileComponent)
      }

      //{
      //  path: 'appointments',
      //  loadComponent: () =>
      //    import('./pages/shared/appointments/appointments')
      //      .then(c => c.AppointmentsComponent)
      //},

      //{
      //  path: 'book-appointment',
      //  loadComponent: () =>
      //    import('./pages/patient/book-appointment/book-appointment')
      //      .then(c => c.BookAppointmentComponent)
      //},

      //{
      //  path: 'health-record',
      //  loadComponent: () =>
      //    import('./pages/patient/health-record/health-record')
      //      .then(c => c.HealthRecordComponent)
      //},

      //{
      //  path: 'leave',
      //  loadComponent: () =>
      //    import('./pages/doctor/add-leave/add-leave')
      //      .then(c => c.AddLeaveComponent)
      //}

    ]
  },

  {
    path: '**',
    redirectTo: ''
  }

];
