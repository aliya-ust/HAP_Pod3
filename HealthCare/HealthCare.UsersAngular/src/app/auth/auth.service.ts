import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = 'https://localhost:7149/api/auth';

  constructor(private readonly http: HttpClient) { }

  login(data: any) {
    return this.http.post(`${this.baseUrl}/login`, data);
  }

  registerPatient(data: any) {
    return this.http.post(`${this.baseUrl}/register/patient`, data);
  }
}
