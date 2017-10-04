import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayingElixrComponent } from './playing-elixr.component';

describe('PlayingElixrComponent', () => {
  let component: PlayingElixrComponent;
  let fixture: ComponentFixture<PlayingElixrComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlayingElixrComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayingElixrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
