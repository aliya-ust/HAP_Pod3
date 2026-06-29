import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../cores/services/auth.services';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterLink
  ],
  templateUrl: './all-login.html',
  styleUrls: ['./all-login.css']
})
export class AllLoginComponent {

  email = '';
  password = '';
  errorMessage = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  login() {

    this.authService.login(this.email, this.password).subscribe({

      next: (response: any) => {

        localStorage.setItem('token', response.accessToken);
        localStorage.setItem('role', response.role);

        if (response.role === 'Admin') {

          window.location.href =
            `https://localhost:7260/login?token=${encodeURIComponent(response.accessToken)}`;

        }
        else {

          // Patient and Doctor both go here
          this.router.navigate(['/dashboard']);

        }

      },

      error: () => {

        this.errorMessage = 'Invalid Email or Password';

      }

    });

  }
}
