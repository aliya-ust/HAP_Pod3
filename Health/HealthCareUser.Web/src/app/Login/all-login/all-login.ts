import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../cores/services/auth.services';
import { CommonModule } from '@angular/common';

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
    private readonly authService: AuthService,
    private readonly router: Router
  ) { }

  login() {

    this.authService.login(this.email, this.password).subscribe({

      next: (response: any) => {

        localStorage.setItem('token', response.accessToken);
        localStorage.setItem('role', response.role);

        if (response.role === 'Admin') {
          globalThis.location.href =
            `http://healthcareapi-dev.eba-jmpubdnp.ap-south-1.elasticbeanstalk.com/blazor/login?token=${encodeURIComponent(response.accessToken)}`;
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
