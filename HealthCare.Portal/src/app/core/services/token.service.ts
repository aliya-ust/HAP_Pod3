import { Injectable } from '@angular/core';

const TOKEN_KEY = 'authToken';
const USER_KEY = 'authUser';

export interface StoredUser {
  role: string;
  patientId?: number;
  doctorId?: number;
}

@Injectable({ providedIn: 'root' })
export class TokenService {
  private decoded: StoredUser | null = null;

  getToken(): string | null {
    return localStorage.getItem(TOKEN_KEY);
  }

  saveToken(token: string): void {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(USER_KEY);
    localStorage.setItem(TOKEN_KEY, token);
    this.decoded = null;
  }

  removeToken(): void {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(USER_KEY);
    this.decoded = null;
  }

  private isTokenExpired(token: string): boolean {
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const exp = payload['exp'] as number | undefined;
      if (!exp) return false;
      return Math.floor(Date.now() / 1000) >= exp;
    } catch {
      return true;
    }
  }

  private ensureTokenValid(): boolean {
    const token = this.getToken();
    if (!token) return false;
    if (this.isTokenExpired(token)) {
      this.removeToken();
      return false;
    }
    return true;
  }

  getUser(): StoredUser | null {
    if (!this.ensureTokenValid()) return null;
    if (this.decoded) return this.decoded;
    const raw = localStorage.getItem(USER_KEY);
    if (raw) {
      this.decoded = JSON.parse(raw);
      return this.decoded;
    }

    const token = this.getToken()!;
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      const user: StoredUser = {
        role: payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'],
        patientId: payload['PatientId'],
        doctorId: payload['DoctorId'],
      };
      localStorage.setItem(USER_KEY, JSON.stringify(user));
      this.decoded = user;
      return user;
    } catch {
      return null;
    }
  }

  isLoggedIn(): boolean {
    return this.ensureTokenValid();
  }

  getRole(): string | null {
    return this.getUser()?.role ?? null;
  }

  getPatientId(): number | null {
    return this.getUser()?.patientId ?? null;
  }

  getDoctorId(): number | null {
    return this.getUser()?.doctorId ?? null;
  }
}
