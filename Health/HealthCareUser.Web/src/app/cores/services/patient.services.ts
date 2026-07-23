import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { PatientProfile } from '../models/PatientProfile';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  private readonly baseUrl = `${environment.apiUrl}`;

  constructor(private readonly http: HttpClient) { }

  getProfile(): Observable<PatientProfile> {
    return this.http.get<PatientProfile>(
      `${this.baseUrl}/patient/profile`
    );
  }

  updateProfile(data: PatientProfile): Observable<any> {
    return this.http.put<any>(
      `${this.baseUrl}/patient/profile`,
      data
    );
  }
}
