import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private readonly router: Router) { }

  canActivate(): boolean {

    const token = localStorage.getItem('token');

    if (!token) {
      this.router.navigate(['/']);
      return false;
    }

    try {

      // Decode the JWT payload
      const payload = JSON.parse(atob(token.split('.')[1]));

      // exp is in seconds, Date.now() is milliseconds
      const isExpired = payload.exp * 1000 < Date.now();

      if (isExpired) {

        localStorage.removeItem('token');
        localStorage.removeItem('role');

        alert('Your session has expired. Please login again.');

        this.router.navigate(['/']);

        return false;
      }

      return true;

    } catch {

      // Invalid token
      localStorage.removeItem('token');
      localStorage.removeItem('role');

      this.router.navigate(['/']);

      return false;
    }
  }
}
