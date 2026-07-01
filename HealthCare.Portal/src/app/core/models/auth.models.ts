export interface LoginDto {
  email: string;
  password: string;
}

export interface RegisterPatientDto {
  fullName: string;
  dateOfBirth: string;
  gender: string;
  phoneNumber: string;
  email: string;
  password: string;
  insuranceId?: string;
}

export interface AuthResponse {
  accessToken: string;
  message: string;
  role: string;
  patientId?: number;
  doctorId?: number;
  expiresIn: number;
}

export interface ChangePasswordDto {
  currentPassword: string;
  newPassword: string;
}

export type UserRole = 'Patient' | 'Doctor' | 'Admin';
