import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';
import { AuthService } from '../../cores/services/auth.services';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './register.html',
  styleUrls: ['./register.css']
})
export class RegisterComponent {

  registerForm: FormGroup;
  submitted = false;
  showSuccessDialog = false;
  loading = false;
  errorMessage = '';

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {

    this.registerForm = this.fb.group({
      fullName: ['', [
        Validators.required,
        Validators.maxLength(100),
        Validators.pattern(/^[A-Za-z\s]+$/)
      ]],

      dateOfBirth: ['', Validators.required],

      gender: ['', [
        Validators.required,
        Validators.pattern(/^(Male|Female|Other)$/)
      ]],

      phoneNumber: ['', [
        Validators.required,
        Validators.pattern(/^[6-9]\d{9}$/)
      ]],

      email: ['', [
        Validators.required,
        Validators.email
      ]],

      password: ['', [
        Validators.required,
        Validators.minLength(8),
        Validators.pattern(
          /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&^#()_+\-=\[\]{};':"\\|,.<>\/?])[A-Za-z\d@$!%*?&^#()_+\-=\[\]{};':"\\|,.<>\/?]{8,}$/
        )
      ]],

      insuranceId: ['', [
        Validators.pattern(/^[A-Za-z0-9]*$/)
      ]]
    });
  }

  get f() {
    return this.registerForm.controls;
  }

  onSubmit() {
    this.submitted = true;
    this.errorMessage = '';

    if (this.registerForm.invalid) return;

    this.loading = true;

    const requestData = {
      fullName: this.registerForm.value.fullName,
      dateOfBirth: this.registerForm.value.dateOfBirth,
      gender: this.registerForm.value.gender,
      phoneNumber: this.registerForm.value.phoneNumber,
      email: this.registerForm.value.email,
      password: this.registerForm.value.password,
      insuranceId: this.registerForm.value.insuranceId
    };

    this.authService.registerPatient(requestData).subscribe({
      next: (res) => {
        this.loading = false;
        this.showSuccessDialog = true;
      },
      error: (err) => {
        this.loading = false;
        this.errorMessage =
          err?.error?.message || 'Registration failed. Try again.';
      }
    });
  }

  goToLogin() {
    this.showSuccessDialog = false;
    this.router.navigate(['/']);
  }
}
