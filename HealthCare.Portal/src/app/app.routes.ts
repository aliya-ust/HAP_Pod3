import { Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { NoAuthGuard } from './core/guards/no-auth.guard';

export const routes: Routes = [
  {
    path: 'logout',
    loadComponent: () => import('./auth/logout/logout').then(m => m.Logout),
  },
  {
    path: 'login',
    canActivate: [NoAuthGuard],
    loadComponent: () => import('./auth/login/login').then(m => m.Login),
  },
  {
    path: 'register',
    canActivate: [NoAuthGuard],
    loadComponent: () => import('./auth/register/register').then(m => m.Register),
  },
  {
    path: 'dashboard',
    canActivate: [AuthGuard],
    loadComponent: () => import('./dashboard/dashboard').then(m => m.Dashboard),
  },
  {
    path: 'book-appointment',
    canActivate: [AuthGuard],
    data: { roles: ['Patient'] },
    loadComponent: () => import('./patient/book-appointment/book-appointment').then(m => m.BookAppointment),
  },
  {
    path: 'my-appointments',
    canActivate: [AuthGuard],
    data: { roles: ['Patient'] },
    loadComponent: () => import('./patient/my-appointments/my-appointments').then(m => m.MyAppointments),
  },
  {
    path: 'my-records',
    canActivate: [AuthGuard],
    data: { roles: ['Patient'] },
    loadComponent: () => import('./patient/my-records/my-records').then(m => m.MyRecords),
  },
  {
    path: 'profile',
    canActivate: [AuthGuard],
    data: { roles: ['Patient'] },
    loadComponent: () => import('./patient/profile/profile').then(m => m.Profile),
  },
  {
    path: 'change-password',
    canActivate: [AuthGuard],
    loadComponent: () => import('./auth/change-password/change-password').then(m => m.ChangePassword),
  },
  {
    path: 'manage-appointments',
    canActivate: [AuthGuard],
    data: { roles: ['Doctor'] },
    loadComponent: () => import('./doctor/manage-appointments/manage-appointments').then(m => m.ManageAppointments),
  },
  {
    path: 'doctor-profile',
    canActivate: [AuthGuard],
    data: { roles: ['Doctor'] },
    loadComponent: () => import('./doctor/doctor-profile/doctor-profile').then(m => m.DoctorProfile),
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' },
];
