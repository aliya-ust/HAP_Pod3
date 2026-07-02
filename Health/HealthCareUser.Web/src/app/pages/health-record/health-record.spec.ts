import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthRecordComponent } from './health-record';

describe('HealthRecord', () => {
  let component: HealthRecordComponent;
  let fixture: ComponentFixture<HealthRecordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HealthRecordComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(HealthRecordComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
