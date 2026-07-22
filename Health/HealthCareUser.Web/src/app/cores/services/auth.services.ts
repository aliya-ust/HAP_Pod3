import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly api = "/api/auth";

  constructor(private readonly http: HttpClient) { }

  // LOGIN
  login(email: string, password: string): Observable<any> {
    return this.http.post(`${this.api}/login`, {
      email,
      password
    });
  }

  // REGISTER PATIENT
  registerPatient(data: any): Observable<any> {
    return this.http.post(`${this.api}/register/patient`, data);
  }
}
