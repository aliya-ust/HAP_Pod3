import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLeaves } from './add-leaves';

describe('AddLeaves', () => {
  let component: AddLeaves;
  let fixture: ComponentFixture<AddLeaves>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddLeaves],
    }).compileComponents();

    fixture = TestBed.createComponent(AddLeaves);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
