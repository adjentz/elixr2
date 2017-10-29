import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OathsComponent } from './oaths.component';

describe('OathsComponent', () => {
  let component: OathsComponent;
  let fixture: ComponentFixture<OathsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OathsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OathsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
