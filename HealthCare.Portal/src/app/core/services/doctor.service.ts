import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { ApiResponse } from '../models/api-response';
import { DoctorListDto, CreateLeaveDto, CreateLeaveResultDto } from '../models/doctor.models';
import { AppointmentListDto, UpdateAppointmentDto } from '../models/appointment.models';
import { CreateHealthRecordDto, HealthRecordListDto } from '../models/health-record.models';

@Injectable({ providedIn: 'root' })
export class DoctorService {
  private readonly baseUrl = `${environment.apiUrl}`;

  constructor(private readonly http: HttpClient) {}

  getProfile(): Observable<DoctorListDto> {
    return this.http.get<ApiResponse<DoctorListDto>>(`${this.baseUrl}/doctors/profile`).pipe(map(r => r.data));
  }

  addLeaves(leaves: CreateLeaveDto[]): Observable<CreateLeaveResultDto> {
    return this.http.post<ApiResponse<CreateLeaveResultDto>>(`${this.baseUrl}/doctors/leaves`, leaves).pipe(map(r => r.data));
  }

  getUpcomingAppointments(): Observable<AppointmentListDto[]> {
    return this.http.get<ApiResponse<AppointmentListDto[]>>(`${this.baseUrl}/appointments/doctor/upcoming`).pipe(map(r => r.data));
  }

  updateAppointmentStatus(id: number, dto: UpdateAppointmentDto): Observable<void> {
    return this.http.put<ApiResponse<void>>(`${this.baseUrl}/appointments/${id}/status`, dto).pipe(map(() => void 0));
  }

  getHealthRecordsByPatient(patientId: number): Observable<HealthRecordListDto[]> {
    return this.http.get<ApiResponse<HealthRecordListDto[]>>(`${this.baseUrl}/records/by-patient/${patientId}`).pipe(map(r => r.data));
  }

  createHealthRecord(dto: CreateHealthRecordDto): Observable<void> {
    return this.http.post<ApiResponse<void>>(`${this.baseUrl}/records/create`, dto).pipe(map(() => void 0));
  }
}
