import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private readonly router: Router) { }

  canActivate(): boolean {

    const token = localStorage.getItem('token'); // or whatever you store

    if (token) {
      return true; // allow access
    }

    // Not logged in → redirect
    this.router.navigate(['/']);
    return false;
  }
}
