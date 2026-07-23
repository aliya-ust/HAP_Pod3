import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { HealthRecord } from '../models/HealthRecord';

@Injectable({
  providedIn: 'root'
})
export class HealthRecordService {

  private readonly baseUrl = `${environment.apiUrl}`;

  constructor(private readonly http: HttpClient) { }

  getPatientHealthRecords(): Observable<HealthRecord[]> {
    return this.http.get<HealthRecord[]>(
      `${this.baseUrl}/HealthRecord/patient`
    );
  }

}
