export interface DoctorListDto {
  doctorId: number;
  fullName: string;
  specialisation: string;
  yearsOfExperience: number;
  consultationFee: number;
  isActive: boolean;
}

export interface AvailableDoctorDto {
  doctorId: number;
  fullName: string;
  specialisation: string;
  yearsOfExperience: number;
  consultationFee: number;
  availableTimeSlots: string[];
}

export interface DoctorFilter {
  search?: string;
  specialisation?: string;
  isActive?: boolean;
  sortBy?: 'experience' | 'fee';
  isDescending?: boolean;
  pageNumber?: number;
  pageSize?: number;
}

export interface AvailableDoctorQuery {
  specialisation: string;
  date: string;
}

export interface CreateLeaveDto {
  leaveDate: string;
  reason?: string;
}

export interface CreateLeaveResultDto {
  skippedDates: string[];
  createdWithCancelledAppointments: string[];
}

export interface UpdateDoctorDto {
  fullName: string;
  specialisation: string;
  yearsOfExperience: number;
}
