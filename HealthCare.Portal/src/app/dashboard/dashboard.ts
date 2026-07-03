import { Component, ComponentRef, ViewChild, ViewContainerRef, OnInit, OnDestroy } from '@angular/core';
import { TokenService } from '../core/services/token.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  templateUrl: './dashboard.html',
})
export class Dashboard implements OnInit, OnDestroy {
  @ViewChild('container', { read: ViewContainerRef, static: true })
  container!: ViewContainerRef;

  private compRef: ComponentRef<any> | null = null;

  constructor(private readonly tokenService: TokenService) {}

  ngOnInit(): void {
    const role = this.tokenService.getRole();
    if (role === 'Patient') {
      import('../patient/dashboard/dashboard').then(({ Dashboard: PatientDash }) => {
        this.compRef = this.container.createComponent(PatientDash);
      });
    } else if (role === 'Doctor') {
      import('../doctor/dashboard/dashboard').then(({ DoctorDashboard }) => {
        this.compRef = this.container.createComponent(DoctorDashboard);
      });
    }
  }

  ngOnDestroy(): void {
    this.compRef?.destroy();
  }
}
