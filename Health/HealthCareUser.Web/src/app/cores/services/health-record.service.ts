import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HealthRecord } from '../models/HealthRecord';

@Injectable({
  providedIn: 'root'
})
export class HealthRecordService {

  private apiUrl = 'https://localhost:7171/api/HealthRecord';

  constructor(private http: HttpClient) { }

  getPatientHealthRecords(): Observable<HealthRecord[]> {
    return this.http.get<HealthRecord[]>(
      `${this.apiUrl}/patient`
    );
  }

}
