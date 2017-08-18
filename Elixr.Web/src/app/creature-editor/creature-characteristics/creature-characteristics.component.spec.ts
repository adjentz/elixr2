import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatureCharacteristicsComponent } from './creature-characteristics.component';

describe('CreatureCharacteristicsComponent', () => {
  let component: CreatureCharacteristicsComponent;
  let fixture: ComponentFixture<CreatureCharacteristicsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatureCharacteristicsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatureCharacteristicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
