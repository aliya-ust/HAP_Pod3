import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ToastService } from '../../core/services/toast.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-change-password',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './change-password.html',
  styleUrl: './change-password.scss',
})
export class ChangePassword {
  currentPassword = '';
  newPassword = '';
  confirmNewPassword = '';
  loading = false;

  private readonly baseUrl = `${environment.apiUrl}/auth`;

  constructor(
    private readonly http: HttpClient,
    private readonly toastService: ToastService,
    private readonly router: Router,
  ) {}

  submit(): void {
    if (this.newPassword !== this.confirmNewPassword) {
      this.toastService.error('Passwords do not match');
      return;
    }

    this.loading = true;
    this.http.post(`${this.baseUrl}/change-password`, {
      currentPassword: this.currentPassword,
      newPassword: this.newPassword,
    }).subscribe({
      next: () => {
        this.loading = false;
        this.toastService.success('Password changed successfully');
        this.router.navigate(['/dashboard']);
      },
      error: () => {
        this.loading = false;
        this.toastService.error('Failed to change password');
      },
    });
  }
}
