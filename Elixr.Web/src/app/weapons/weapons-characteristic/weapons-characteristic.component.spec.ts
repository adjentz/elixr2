import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WeaponsCharacteristicComponent } from './weapons-characteristic.component';

describe('WeaponsCharacteristicComponent', () => {
  let component: WeaponsCharacteristicComponent;
  let fixture: ComponentFixture<WeaponsCharacteristicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WeaponsCharacteristicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WeaponsCharacteristicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
