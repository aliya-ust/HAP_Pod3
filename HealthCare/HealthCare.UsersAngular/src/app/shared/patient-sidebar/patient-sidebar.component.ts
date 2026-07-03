import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-patient-sidebar',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './patient-sidebar.component.html',
  styleUrls: ['./patient-sidebar.component.css']
})
export class PatientSidebarComponent {

  constructor(private readonly router: Router) { }

  logout() {

    localStorage.clear();

    this.router.navigate(['/']);
  }
}
