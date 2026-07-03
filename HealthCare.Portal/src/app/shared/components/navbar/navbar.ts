import { Component } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

import { AuthService } from '../../../core/services/auth.service';
import { TokenService } from '../../../core/services/token.service';

interface NavLink {
  label: string;
  route: string;
  roles: string[];
}

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
})
export class Navbar {
  links: NavLink[] = [
    { label: 'Dashboard', route: '/dashboard', roles: ['Patient', 'Doctor'] },
    { label: 'Book Appointment', route: '/book-appointment', roles: ['Patient'] },
    { label: 'My Appointments', route: '/my-appointments', roles: ['Patient'] },
    { label: 'My Records', route: '/my-records', roles: ['Patient'] },
    { label: 'Profile', route: '/profile', roles: ['Patient'] },
    { label: 'Manage Appointments', route: '/manage-appointments', roles: ['Doctor'] },
    { label: 'Doctor Profile', route: '/doctor-profile', roles: ['Doctor'] },
    { label: 'Change Password', route: '/change-password', roles: ['Patient', 'Doctor'] },
  ];

  menuOpen = false;

  constructor(
    public authService: AuthService,
    public tokenService: TokenService,
    private readonly router: Router,
  ) {}

  get visibleLinks(): NavLink[] {
    const role = this.tokenService.getRole();
    return this.links.filter(l => l.roles.includes(role ?? ''));
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  toggleMenu(): void {
    this.menuOpen = !this.menuOpen;
  }
}
