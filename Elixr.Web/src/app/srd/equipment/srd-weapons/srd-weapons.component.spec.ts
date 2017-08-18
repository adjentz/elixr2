import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SrdWeaponsComponent } from './srd-weapons.component';

describe('SrdWeaponsComponent', () => {
  let component: SrdWeaponsComponent;
  let fixture: ComponentFixture<SrdWeaponsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SrdWeaponsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SrdWeaponsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
