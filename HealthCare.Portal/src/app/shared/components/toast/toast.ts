import { Component } from '@angular/core';
import { NgFor, NgClass } from '@angular/common';
import { ToastService } from '../../../core/services/toast.service';

@Component({
  selector: 'app-toast',
  standalone: true,
  imports: [NgFor, NgClass],
  templateUrl: './toast.html',
  styleUrl: './toast.scss',
})
export class Toast {
  constructor(public toastService: ToastService) {}
}
