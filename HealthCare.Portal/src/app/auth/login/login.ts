import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { ToastService } from '../../core/services/toast.service';
import { TokenService } from '../../core/services/token.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {
  email = '';
  password = '';
  loading = signal(false);

  constructor(
    private readonly authService: AuthService,
    private readonly toastService: ToastService,
    private readonly tokenService: TokenService,
    private readonly router: Router,
  ) {}

  login(): void {
    if (!this.email || !this.password) return;
    this.loading.set(true);
    this.authService.login({ email: this.email, password: this.password }).subscribe({
      next: () => {
        this.loading.set(false);
        this.redirectByRole();
      },
      error: () => {
        this.loading.set(false);
        this.toastService.error('Invalid email or password');
      },
    });
  }

  private redirectByRole(): void {
    const role = this.tokenService.getRole();
    if (role === 'Admin') {
      const token = this.tokenService.getToken();
      globalThis.location.href = `https://localhost:7166/auth-callback?token=${token}`;
    } else if (role === 'Patient' || role === 'Doctor') {
      this.router.navigate(['/dashboard']);
    } else {
      this.router.navigate(['/login']);
    }
  }
}
