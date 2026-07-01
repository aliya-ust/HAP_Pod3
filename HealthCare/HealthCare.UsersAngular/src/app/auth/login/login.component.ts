import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;

  errors: any = {};

  constructor(
    private auth: AuthService,
    private router: Router,
    private fb: FormBuilder
  ) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  login() {

    this.errors.top = '';

    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.auth.login(this.loginForm.value).subscribe({

      next: (res: any) => {

        if (!res || !res.accessToken) {
          this.errors.top = 'Invalid email or password';
          return;
        }

        localStorage.setItem('token', res.accessToken);
        localStorage.setItem('role', res.role);

        if (res.role === 'Admin') {

          window.location.href =
            'https://localhost:7206/dashboard?token=' + res.accessToken;

        } else if (res.role === 'Patient') {

          this.router.navigate(['/patient-dashboard']);

        } else if (res.role === 'Doctor') {

          this.router.navigate(['/doctor-dashboard']);

        } else {
          this.errors.top = 'Invalid email or password';
        }
      },

      error: (err) => {

        console.log("FULL ERROR:", err);

        if (err.status === 400 || err.status === 401) {
          this.errors.top = 'Invalid email or password';
        } else {
          this.errors.top = 'Something went wrong. Try again.';
        }
      }

    });
  }

  goPatientRegister() {
    this.router.navigate(['/register-patient']);
  }

}
