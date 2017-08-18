import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatureDescriptionComponent } from './creature-description.component';

describe('CreatureDescriptionComponent', () => {
  let component: CreatureDescriptionComponent;
  let fixture: ComponentFixture<CreatureDescriptionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatureDescriptionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatureDescriptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
