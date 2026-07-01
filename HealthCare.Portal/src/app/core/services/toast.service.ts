import { Injectable, signal } from '@angular/core';

export interface ToastMessage {
  id: number;
  text: string;
  type: 'success' | 'error' | 'info' | 'warning';
}

@Injectable({ providedIn: 'root' })
export class ToastService {
  private idCounter = 0;
  messages = signal<ToastMessage[]>([]);

  show(text: string, type: ToastMessage['type'] = 'info', duration = 5000): void {
    const id = ++this.idCounter;
    this.messages.update(m => [...m, { id, text, type }]);
    setTimeout(() => this.remove(id), duration);
  }

  success(text: string): void {
    this.show(text, 'success');
  }

  error(text: string): void {
    this.show(text, 'error');
  }

  info(text: string): void {
    this.show(text, 'info');
  }

  warning(text: string): void {
    this.show(text, 'warning');
  }

  remove(id: number): void {
    this.messages.update(m => m.filter(x => x.id !== id));
  }
}
