import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { DoctorProfile } from '../models/DoctorProfile';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  private readonly apiUrl = 'https://localhost:7171/api';

  constructor(private readonly http: HttpClient) { }

  getProfile(): Observable<DoctorProfile> {
    return this.http.get<DoctorProfile>(
      `${this.apiUrl}/doctor/profile`
    );
  }
}
