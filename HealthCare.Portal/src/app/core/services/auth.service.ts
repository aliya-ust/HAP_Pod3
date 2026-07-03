import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap, map } from 'rxjs';
import { AuthResponse, LoginDto, RegisterPatientDto } from '../models/auth.models';
import { ApiResponse } from '../models/api-response';
import { TokenService } from './token.service';
import { environment } from '../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly baseUrl = `${environment.apiUrl}/auth`;

  constructor(
    private readonly http: HttpClient,
    private readonly tokenService: TokenService,
  ) {}

  login(dto: LoginDto): Observable<AuthResponse> {
    return this.http.post<ApiResponse<AuthResponse>>(`${this.baseUrl}/login`, dto)
      .pipe(
        tap(wrapper => {
          if (wrapper.data?.accessToken) {
            this.tokenService.saveToken(wrapper.data.accessToken);
          }
        }),
        map(wrapper => wrapper.data)
      );
  }

  registerPatient(dto: RegisterPatientDto): Observable<Object> {
    return this.http.post(`${this.baseUrl}/register/patient`, dto);
  }

  logout(): void {
    this.tokenService.removeToken();
  }

  isLoggedIn(): boolean {
    return this.tokenService.isLoggedIn();
  }

  getRole(): string | null {
    return this.tokenService.getRole();
  }
}
