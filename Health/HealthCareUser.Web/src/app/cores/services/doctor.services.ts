import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { DoctorProfile } from '../models/DoctorProfile';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  private readonly baseUrl = `${environment.apiUrl}`;

  constructor(private readonly http: HttpClient) { }

  getProfile(): Observable<DoctorProfile> {
    return this.http.get<DoctorProfile>(
      `${this.baseUrl}/doctor/profile`
    );
  }
}
