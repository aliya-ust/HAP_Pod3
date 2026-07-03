export interface Appointment {

  appointmentId: number;

  patientId: number;
  patientName: string;

  doctorId: number;
  doctorName: string;

  scheduledDate: string;
  timeSlot: string;

  status: string;

}

export interface DoctorDropdownDto {
  doctorId: number;
  fullName: string;
  specialization: string;
}

export interface CreateAppointmentDto {
  doctorId: number;
  scheduledDate: string;
  timeSlot: string;
  reason?: string;
}
