import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateLeave, CreateLeaveResult } from '../models/doctor-leave';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DoctorLeaveService {

  private readonly baseUrl = `${environment.apiUrl}`;

  constructor(private readonly http: HttpClient) { }

  createLeaves(leaves: CreateLeave[]): Observable<CreateLeaveResult> {
    return this.http.post<CreateLeaveResult>(
      `${this.baseUrl}/Doctor/leave`,
      leaves
    );
  }

}
