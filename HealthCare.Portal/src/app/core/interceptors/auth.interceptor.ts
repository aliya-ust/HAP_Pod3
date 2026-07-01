import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TokenService } from '../services/token.service';
import { ToastService } from '../services/toast.service';
import { extractErrorMessage } from '../utils/error-utils';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenService = inject(TokenService);
  const router = inject(Router);
  const toast = inject(ToastService);

  const token = tokenService.getToken();
  if (token) {
    req = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` },
    });
  }

  return next(req).pipe(
    catchError((err: HttpErrorResponse) => {
      const msg = extractErrorMessage(err);
      if (err.status === 401) {
        tokenService.removeToken();
        toast.error('Session expired. Please login again.');
        router.navigate(['/login']);
      } else if (err.status === 403) {
        toast.error(msg || 'Access denied.');
        router.navigate(['/login']);
      }
      return throwError(() => err);
    }),
  );
};
