export interface HealthRecordListDto {
  recordId: number;
  patientName: string;
  doctorName: string;
  visitDate: string;
  diagnosis: string;
  prescription: string;
  notes: string | null;
}

export interface CreateHealthRecordDto {
  appointmentId: number;
  patientId: number;
  visitDate: string;
  diagnosis: string;
  prescription: string;
  notes?: string;
}
