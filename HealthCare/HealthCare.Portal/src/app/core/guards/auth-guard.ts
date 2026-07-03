import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authGuard: CanActivateFn = (route) => {
  const router = inject(Router);

  const token = localStorage.getItem('token');
  const role = localStorage.getItem('role')?.toUpperCase();

  const expectedRole = route.data['role'];

  if (!token || !role) {
    router.navigate(['/login']);
    return false;
  }

  if (expectedRole && role !== expectedRole) {
    if (role === 'PATIENT') {
      router.navigate(['/patient']);
      return false;
    }

    if (role === 'DOCTOR') {
      router.navigate(['/doctor']);
      return false;
    }

    router.navigate(['/login']);
    return false;
  }

  return true;
};
