import { HttpErrorResponse } from '@angular/common/http';

export function extractErrorMessage(err: unknown): string {
  if (err instanceof HttpErrorResponse) {
    const body = err.error;
    if (body?.message) return body.message;
    if (body?.errors?.length) return body.errors[0];
    if (body?.title) return body.title;
    if (body?.detail) return body.detail;
    if (typeof body === 'string') return body;
    if (err.status) return `HTTP ${err.status}`;
  }
  return 'An unexpected error occurred';
}
