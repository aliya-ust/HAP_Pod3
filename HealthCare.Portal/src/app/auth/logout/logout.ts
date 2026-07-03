import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenService } from '../../core/services/token.service';

@Component({
  standalone: true,
  template: '',
})
export class Logout implements OnInit {
  constructor(
    private readonly tokenService: TokenService,
    private readonly router: Router,
  ) {}

  ngOnInit(): void {
    this.tokenService.removeToken();
    this.router.navigate(['/login'], { replaceUrl: true });
  }
}
