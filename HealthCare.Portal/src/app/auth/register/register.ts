import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgIf, NgFor } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { ToastService } from '../../core/services/toast.service';
import { extractErrorMessage } from '../../core/utils/error-utils';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, RouterLink, NgIf, NgFor],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
  fullName = '';
  email = '';
  password = '';
  confirmPassword = '';
  dateOfBirth = '';
  gender = '';
  phoneNumber = '';
  insuranceId = '';
  loading = signal(false);

  readonly passwordPattern = '^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$';
  readonly phonePattern = '[6-9][0-9]{9}';
  readonly namePattern = '[A-Za-z ]+';
  readonly emailPattern = '[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}';

  get yesterday(): string {
    const d = new Date();
    d.setDate(d.getDate() - 1);
    return d.toISOString().split('T')[0];
  }

  constructor(
    private readonly authService: AuthService,
    private readonly toastService: ToastService,
    private readonly router: Router,
  ) {}

  register(): void {
    if (this.password !== this.confirmPassword) {
      this.toastService.error('Passwords do not match');
      return;
    }

    this.loading.set(true);
    this.authService.registerPatient({
      fullName: this.fullName,
      email: this.email,
      password: this.password,
      dateOfBirth: this.dateOfBirth,
      gender: this.gender,
      phoneNumber: this.phoneNumber,
      insuranceId: this.insuranceId || undefined,
    }).subscribe({
      next: () => {
        this.loading.set(false);
        this.toastService.success('Registration successful. Please sign in.');
        this.router.navigate(['/login']);
      },
      error: (err) => {
        this.loading.set(false);
        this.toastService.error(extractErrorMessage(err));
      },
    });
  }
}
