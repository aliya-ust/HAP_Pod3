import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators, FormGroup } from '@angular/forms';
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

  // ✅ Signals
  submitted = signal(false);
  showSuccessDialog = signal(false);
  loading = signal(false);
  errorMessage = signal('');

  registerForm!: FormGroup; // ✅ declare first

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {

    // ✅ Initialize inside constructor
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
          /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&^#()_+\-=\[\]{};':"\\|,.<>\/?]).{8,}$/
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
    this.submitted.set(true);
    this.errorMessage.set('');

    if (this.registerForm.invalid) return;

    this.loading.set(true);

    this.authService.registerPatient(this.registerForm.value).subscribe({
      next: () => {
        this.loading.set(false);
        this.showSuccessDialog.set(true);
      },
      error: (err) => {
        this.loading.set(false);
        this.errorMessage.set(
          err?.error?.message || 'Registration failed. Try again.'
        );
      }
    });
  }

  goToLogin() {
    this.showSuccessDialog.set(false);
    this.router.navigateByUrl('/');
  }
}
