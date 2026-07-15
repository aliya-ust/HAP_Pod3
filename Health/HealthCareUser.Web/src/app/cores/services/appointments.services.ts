import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { Appointment, DoctorDropdownDto, CreateAppointmentDto } from '../models/Appointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  private readonly apiUrl = 'https://localhost:7171/api/Appointment';

  date: string = '';
  specialization: string = '';
  selectedDoctorId: number | null = null;
  selectedSlot: string = '';

  doctors: DoctorDropdownDto[] = [];
  timeSlots: string[] = [];

  patientAppointments: Appointment[] = [];
  doctorAppointments: Appointment[] = [];

  constructor(private readonly http: HttpClient) { }

  // PATIENT APPOINTMENTS
  getPatientAppointments(): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.apiUrl}/patient`)
      .pipe(
        tap(data => this.patientAppointments = data)
      );
  }

  // DOCTOR APPOINTMENTS
  getDoctorAppointments(): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(`${this.apiUrl}/doctor`)
      .pipe(
        tap(data => this.doctorAppointments = data)
      );
  }

  confirmAppointment(id: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}/confirm`, {});
  }

  cancelAppointment(id: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}/cancel`, {});
  }

  //  BOOKING FLOW
  getAvailableDoctors(date: string, specialization: string): Observable<DoctorDropdownDto[]> {

    const params = new HttpParams()
      .set('date', date)
      .set('specialisation', specialization);

    return this.http.get<DoctorDropdownDto[]>(
      `https://localhost:7171/api/Doctor/available`, 
      { params }
    );
  }


  // Get health records of a patient
  getHealthRecordsByPatient(patientId: number): Observable<any[]> {
    return this.http.get<any[]>(`https://localhost:7171/api/HealthRecord/patient/${patientId}`);
  }

  // Create new health record
  createHealthRecord(dto: any): Observable<any> {
    return this.http.post(`https://localhost:7171/api/HealthRecord`, dto);
  }


  getAvailableSlots(doctorId: number, date: string): Observable<string[]> {

    let params = new HttpParams()
      .set('doctorId', doctorId)
      .set('date', date);

    return this.http.get<string[]>(`${this.apiUrl}/available-slots`, { params })
      .pipe(
        tap(res => this.timeSlots = res) // cache
      );
  }

  bookAppointment(dto: CreateAppointmentDto): Observable<any> {
    return this.http.post(`${this.apiUrl}`, dto);
  }
}
