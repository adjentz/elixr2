import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatureAttacksComponent } from './creature-attacks.component';

describe('CreatureAttacksComponent', () => {
  let component: CreatureAttacksComponent;
  let fixture: ComponentFixture<CreatureAttacksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatureAttacksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatureAttacksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
