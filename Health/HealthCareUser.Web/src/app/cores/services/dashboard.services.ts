import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { PatientDashboard } from '../models/PatientDashboard';
import { DoctorDashboard } from '../models/DoctorDashboard';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  private readonly apiUrl = '/api/dashboard';

  constructor(private readonly http: HttpClient) { }

  getPatientDashboard(): Observable<PatientDashboard> {

    return this.http.get<PatientDashboard>(
      `${this.apiUrl}/patient`
    );

  }

  getDoctorDashboard(): Observable<DoctorDashboard> {

    return this.http.get<DoctorDashboard>(
      `${this.apiUrl}/doctor`
    );

  }

}
