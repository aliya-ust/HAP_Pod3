import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { PatientProfile } from '../models/PatientProfile';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private apiUrl = 'https://localhost:7171/api';

  constructor(private http: HttpClient) { }

  getProfile(): Observable<PatientProfile> {
    return this.http.get<PatientProfile>(
      `${this.apiUrl}/patient/profile`
    );
  }

  updateProfile(data: PatientProfile): Observable<any> {
    return this.http.put<any>(
      `${this.apiUrl}/patient/profile`,
      data
    );
  }
}
