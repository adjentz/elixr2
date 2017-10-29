import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayerDeathComponent } from './player-death.component';

describe('PlayerDeathComponent', () => {
  let component: PlayerDeathComponent;
  let fixture: ComponentFixture<PlayerDeathComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlayerDeathComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayerDeathComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
