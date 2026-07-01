import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-session-expired-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './session-expired-modal.component.html',
  styleUrls: ['./session-expired-modal.component.css']
})
export class SessionExpiredModalComponent {

  @Input() visible = false;
  @Output() close = new EventEmitter();

  onOk() {
    this.close.emit();
  }
}
