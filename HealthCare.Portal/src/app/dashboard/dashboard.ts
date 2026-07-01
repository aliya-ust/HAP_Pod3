import { Component, ComponentRef, ViewChild, ViewContainerRef, OnDestroy } from '@angular/core';
import { TokenService } from '../core/services/token.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  templateUrl: './dashboard.html',
})
export class Dashboard implements OnDestroy {
  @ViewChild('container', { read: ViewContainerRef, static: true })
  container!: ViewContainerRef;

  private compRef: ComponentRef<any> | null = null;

  constructor(private readonly tokenService: TokenService) {}

  async ngOnInit(): Promise<void> {
    const role = this.tokenService.getRole();
    if (role === 'Patient') {
      const { Dashboard: PatientDash } = await import('../patient/dashboard/dashboard');
      this.compRef = this.container.createComponent(PatientDash);
    } else if (role === 'Doctor') {
      const { DoctorDashboard } = await import('../doctor/dashboard/dashboard');
      this.compRef = this.container.createComponent(DoctorDashboard);
    }
  }

  ngOnDestroy(): void {
    this.compRef?.destroy();
  }
}
