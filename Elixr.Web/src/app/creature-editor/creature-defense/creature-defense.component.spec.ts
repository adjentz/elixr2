import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatureDefenseComponent } from './creature-defense.component';

describe('CreatureDefenseComponent', () => {
  let component: CreatureDefenseComponent;
  let fixture: ComponentFixture<CreatureDefenseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatureDefenseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatureDefenseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
