export interface CreateAppointmentDto {
  doctorId: number;
  scheduledDate: string;
  timeSlot: string;
}

export interface UpdateAppointmentDto {
  status: 'Confirmed' | 'Cancelled';
  cancellationReason?: string;
}

export interface AppointmentListDto {
  appointmentId: number;
  patientId: number;
  patientName: string;
  doctorName: string;
  scheduledDate: string;
  timeSlot: string;
  status: string;
}

export interface AppointmentFilter {
  status?: string;
  pageNumber?: number;
  pageSize?: number;
}

export type AppointmentStatus = 'Pending' | 'Confirmed' | 'Cancelled' | 'Completed';
