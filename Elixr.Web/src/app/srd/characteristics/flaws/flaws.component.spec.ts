import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlawsComponent } from './flaws.component';

describe('FlawsComponent', () => {
  let component: FlawsComponent;
  let fixture: ComponentFixture<FlawsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlawsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlawsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
