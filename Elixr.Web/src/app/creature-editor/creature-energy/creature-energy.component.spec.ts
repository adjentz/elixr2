import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatureEnergyComponent } from './creature-energy.component';

describe('CreatureEnergyComponent', () => {
  let component: CreatureEnergyComponent;
  let fixture: ComponentFixture<CreatureEnergyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatureEnergyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatureEnergyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
