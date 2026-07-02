import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateLeave, CreateLeaveResult } from '../models/doctor-leave';

@Injectable({
  providedIn: 'root'
})
export class DoctorLeaveService {

  private apiUrl = 'https://localhost:7171/api/Doctor';

  constructor(private http: HttpClient) { }

  createLeaves(leaves: CreateLeave[]): Observable<CreateLeaveResult> {
    return this.http.post<CreateLeaveResult>(
      `${this.apiUrl}/leave`,
      leaves
    );
  }

}
