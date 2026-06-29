import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllLoginComponent } from './all-login';

describe('AllLoginComponent', () => {
  let component: AllLoginComponent;
  let fixture: ComponentFixture<AllLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AllLoginComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(AllLoginComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
