import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoctorLeaveComponent } from './doctor-leave';

describe('DoctorLeave', () => {
  let component: DoctorLeaveComponent;
  let fixture: ComponentFixture<DoctorLeaveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DoctorLeaveComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(DoctorLeaveComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
