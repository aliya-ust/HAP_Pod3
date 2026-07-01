export interface PatientListDto {
  patientId: number;
  fullName: string;
  email: string;
  phoneNumber: string;
  gender: string;
  insuranceId: string | null;
  isActive: boolean;
}

export interface UpdatePatientDto {
  fullName: string;
  phoneNumber: string;
  email: string;
  gender: string;
  insuranceId?: string;
}

export interface PatientFilter {
  search?: string;
  hasInsurance?: boolean;
  isActive?: boolean;
  pageNumber?: number;
  pageSize?: number;
}
