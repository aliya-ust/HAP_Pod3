import { inject } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivateFn,
  Router
} from '@angular/router';

export const roleGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot
) => {

  const router = inject(Router);

  const role = localStorage.getItem('role');

  const allowedRoles = route.data['roles'] as string[];

  if (allowedRoles?.includes(role!)) {
    return true;
  }

  if (role === 'Patient') {
    return router.createUrlTree(['/patient-dashboard']);
  }

  if (role === 'Doctor') {
    return router.createUrlTree(['/doctor-dashboard']);
  }

  return router.createUrlTree(['/']);
};
