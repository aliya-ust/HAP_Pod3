import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './sidebar.html',
  styleUrls: ['./sidebar.css']
})
export class SidebarComponent implements OnInit {

  role = '';

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.role = localStorage.getItem('role') ?? '';
  }

  logout() {

    localStorage.removeItem('token');
    localStorage.removeItem('role');

    this.router.navigate(['/login']);

  }

}
