import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private api = "https://localhost:7171/api/auth";

  constructor(private http: HttpClient) { }

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
