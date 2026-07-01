import {
  Component,
  DoCheck,
  OnInit,
  ChangeDetectorRef
} from '@angular/core';

import { RouterOutlet } from '@angular/router';
import { Router } from '@angular/router';

import { AuthInterceptor } from './core/auth-interceptor';
import { SessionExpiredModalComponent } from './shared/session-expired-modal/session-expired-modal.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SessionExpiredModalComponent],
  templateUrl: './app.html'
})
export class AppComponent implements DoCheck, OnInit {

  sessionExpired = false;

  constructor(
    private router: Router,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {

    setInterval(() => {

      const token = localStorage.getItem('token');

      if (!token || this.sessionExpired)
        return;

      try {

        const payload =
          JSON.parse(atob(token.split('.')[1]));

        const now =
          Math.floor(Date.now() / 1000);

        if (payload.exp <= now) {

          this.sessionExpired = true;

          AuthInterceptor.sessionExpired = true;

          localStorage.clear();
        }

      }
      catch {

        localStorage.clear();
      }

    }, 5000);
  }

  ngDoCheck(): void {

    const currentValue =
      AuthInterceptor.sessionExpired;

    if (this.sessionExpired !== currentValue) {

      this.sessionExpired = currentValue;

      this.cdr.detectChanges();
    }
  }

  handleClose() {

    this.sessionExpired = false;

    AuthInterceptor.sessionExpired = false;

    localStorage.clear();

    this.router.navigate(['/']);
  }
}
