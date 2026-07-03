export type UserRole = 'Admin' | 'Patient' | 'Doctor';

export interface LoginRequest {
  email: string;
  password: string;
}

export interface AuthResponse {
  accessToken: string;
  message: string;
  role: UserRole;
  patientId?: number;
  doctorId?: number;
  expiresIn: number;
}

export interface RegisterPatientRequest {
  fullName: string;
  dateOfBirth: string;
  gender: string;
  phoneNumber: string;
  email: string;
  password: string;
  insuranceId?: string;
}
