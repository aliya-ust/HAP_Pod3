import { Injectable } from '@angular/core';
import { CanActivate, Router, UrlTree } from '@angular/router';
import { TokenService } from '../services/token.service';

@Injectable({ providedIn: 'root' })
export class NoAuthGuard implements CanActivate {
  constructor(
    private readonly tokenService: TokenService,
    private readonly router: Router,
  ) {}

  canActivate(): boolean | UrlTree {
    if (this.tokenService.isLoggedIn()) {
      return this.router.parseUrl('/dashboard');
    }
    return true;
  }
}
