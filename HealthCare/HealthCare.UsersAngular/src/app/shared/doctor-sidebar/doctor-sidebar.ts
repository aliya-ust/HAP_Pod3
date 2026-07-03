import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-doctor-sidebar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './doctor-sidebar.html',
  styleUrls: ['./doctor-sidebar.css']
})
export class DoctorSidebarComponent {

  constructor(private readonly router: Router) { }

  logout() {
    localStorage.clear();
    this.router.navigate(['/']);
  }
}
