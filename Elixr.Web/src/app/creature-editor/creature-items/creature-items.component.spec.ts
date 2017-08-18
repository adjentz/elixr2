import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatureItemsComponent } from './creature-items.component';

describe('CreatureItemsComponent', () => {
  let component: CreatureItemsComponent;
  let fixture: ComponentFixture<CreatureItemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatureItemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatureItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
