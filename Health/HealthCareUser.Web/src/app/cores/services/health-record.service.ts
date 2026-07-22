import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HealthRecord } from '../models/HealthRecord';

@Injectable({
  providedIn: 'root'
})
export class HealthRecordService {

  private readonly apiUrl = '/api/HealthRecord';

  constructor(private readonly http: HttpClient) { }

  getPatientHealthRecords(): Observable<HealthRecord[]> {
    return this.http.get<HealthRecord[]>(
      `${this.apiUrl}/patient`
    );
  }

}
