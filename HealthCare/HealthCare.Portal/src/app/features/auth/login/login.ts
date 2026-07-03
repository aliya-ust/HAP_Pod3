import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { environment } from '../../../../environments/environment';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage = '';
  isLoading = false;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  login(): void {
    this.errorMessage = '';

    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.isLoading = true;

    this.authService.login(this.loginForm.value).subscribe({
      next: (response) => {
        const role = (response.role ?? '').toUpperCase();

        localStorage.setItem('token', response.accessToken);
        localStorage.setItem('role', role);

        this.isLoading = false;

        if (role === 'ADMIN') {
          this.redirectToBlazorAdmin(response.accessToken);
          return;
        }

        if (role === 'PATIENT') {
          this.router.navigate(['/patient']);
          return;
        }

        if (role === 'DOCTOR') {
          this.router.navigate(['/doctor']);
          return;
        }

        this.errorMessage = 'Invalid user role.';
      },

      error: (error) => {
        console.error('Login error:', error);

        this.errorMessage =
          error?.error?.message ||
          error?.error ||
          'Invalid email or password.';

        this.isLoading = false;
      }
    });
  }

  private redirectToBlazorAdmin(accessToken: string): void {
    const redirectUrl =
      `${environment.blazorAdminUrl}/auth-callback?token=${encodeURIComponent(accessToken)}&role=Admin`;

    window.location.href = redirectUrl;
  }

  isInvalid(controlName: string): boolean {
    const control = this.loginForm.get(controlName);
    return !!control && control.invalid && (control.dirty || control.touched);
  }
}
