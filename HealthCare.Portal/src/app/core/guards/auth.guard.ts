import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { TokenService } from '../services/token.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(
    private readonly tokenService: TokenService,
    private readonly router: Router,
  ) {}

  canActivate(route: ActivatedRouteSnapshot, _state: RouterStateSnapshot): boolean | UrlTree {
    if (!this.tokenService.isLoggedIn()) {
      return this.router.parseUrl('/login');
    }

    const allowedRoles = route.data?.['roles'] as string[] | undefined;
    if (allowedRoles && allowedRoles.length > 0) {
      const role = this.tokenService.getRole();
      if (!role || !allowedRoles.includes(role)) {
        return this.router.parseUrl('/login');
      }
    }

    return true;
  }
}
