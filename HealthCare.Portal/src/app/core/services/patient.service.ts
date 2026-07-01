import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ApiResponse } from '../models/api-response';
import { PatientListDto, UpdatePatientDto } from '../models/patient.models';
import { DoctorListDto } from '../models/doctor.models';
import { AppointmentListDto, CreateAppointmentDto } from '../models/appointment.models';
import { HealthRecordListDto } from '../models/health-record.models';

@Injectable({ providedIn: 'root' })
export class PatientService {
  private readonly baseUrl = `${environment.apiUrl}`;

  constructor(private readonly http: HttpClient) {}

  getProfile(): Observable<PatientListDto> {
    return this.http.get<ApiResponse<PatientListDto>>(`${this.baseUrl}/patients/profile`).pipe(map(r => r.data));
  }

  updateProfile(dto: UpdatePatientDto): Observable<void> {
    return this.http.put<ApiResponse<void>>(`${this.baseUrl}/patients/profile`, dto).pipe(map(() => void 0));
  }

  getAvailableDoctors(specialisation: string, date: string): Observable<DoctorListDto[]> {
    return this.http.get<ApiResponse<DoctorListDto[]>>(`${this.baseUrl}/doctors/available`, {
      params: { specialisation, date },
    }).pipe(map(r => r.data));
  }

  getAvailableSlots(doctorId: number, date: string): Observable<string[]> {
    return this.http.get<ApiResponse<string[]>>(`${this.baseUrl}/appointments/available-slots`, {
      params: { doctorId, date },
    }).pipe(map(r => r.data));
  }

  bookAppointment(dto: CreateAppointmentDto): Observable<void> {
    return this.http.post<ApiResponse<void>>(`${this.baseUrl}/appointments/book`, dto).pipe(map(() => void 0));
  }

  getUpcomingAppointments(): Observable<AppointmentListDto[]> {
    return this.http.get<ApiResponse<AppointmentListDto[]>>(`${this.baseUrl}/appointments/patient/upcoming`).pipe(map(r => r.data));
  }

  getMyHealthRecords(): Observable<HealthRecordListDto[]> {
    return this.http.get<ApiResponse<HealthRecordListDto[]>>(`${this.baseUrl}/records/my-records`).pipe(map(r => r.data));
  }
}
