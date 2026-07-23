import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { PatientDashboard } from '../models/PatientDashboard';
import { DoctorDashboard } from '../models/DoctorDashboard';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  private readonly baseUrl = `${environment.apiUrl}`;

  constructor(private readonly http: HttpClient) { }

  getPatientDashboard(): Observable<PatientDashboard> {

    return this.http.get<PatientDashboard>(
      `${this.baseUrl}/dashboard/patient`
    );

  }

  getDoctorDashboard(): Observable<DoctorDashboard> {

    return this.http.get<DoctorDashboard>(
      `${this.baseUrl}/dashboard/doctor`
    );

  }

}
