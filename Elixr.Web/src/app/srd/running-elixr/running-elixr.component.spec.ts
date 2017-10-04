import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RunningElixrComponent } from './running-elixr.component';

describe('RunningElixrComponent', () => {
  let component: RunningElixrComponent;
  let fixture: ComponentFixture<RunningElixrComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RunningElixrComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RunningElixrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
