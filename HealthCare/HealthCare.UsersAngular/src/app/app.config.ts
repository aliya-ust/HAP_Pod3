import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient, withInterceptorsFromDi, HTTP_INTERCEPTORS} from '@angular/common/http';

import { routes } from './app.routes';
import { AuthInterceptor } from './core/auth-interceptor';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),

    // HttpClient
    provideHttpClient(withInterceptorsFromDi()),

    // Interceptor
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ]
};
