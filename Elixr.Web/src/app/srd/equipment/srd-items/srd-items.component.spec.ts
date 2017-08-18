import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SrdItemsComponent } from './srd-items.component';

describe('SrdItemsComponent', () => {
  let component: SrdItemsComponent;
  let fixture: ComponentFixture<SrdItemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SrdItemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SrdItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
