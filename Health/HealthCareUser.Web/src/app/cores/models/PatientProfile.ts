export interface PatientProfile {

  patientId: number;

  fullName: string;

  email: string;

  phoneNumber: string;

  dateOfBirth: string;

  gender: string;

  insuranceId: number;
}

export interface UpdatePatient {
  fullName: string;
  phoneNumber: string;
  gender: string;
  insuranceId: string;
}

