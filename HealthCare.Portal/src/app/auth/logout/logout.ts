import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from '../../core/services/token.service';

@Component({
  standalone: true,
  template: '',
})
export class Logout {
  constructor(
    private readonly tokenService: TokenService,
    private readonly router: Router,
  ) {
    this.tokenService.removeToken();
    this.router.navigate(['/login'], { replaceUrl: true });
  }
}
