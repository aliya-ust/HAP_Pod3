import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateLeave, CreateLeaveResult } from '../models/doctor-leave';

@Injectable({
  providedIn: 'root'
})
export class DoctorLeaveService {

  private readonly apiUrl = '/api/Doctor';

  constructor(private readonly http: HttpClient) { }

  createLeaves(leaves: CreateLeave[]): Observable<CreateLeaveResult> {
    return this.http.post<CreateLeaveResult>(
      `${this.apiUrl}/leave`,
      leaves
    );
  }

}
