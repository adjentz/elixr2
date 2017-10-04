import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatingACharacterComponent } from './creating-a-character.component';

describe('CreatingACharacterComponent', () => {
  let component: CreatingACharacterComponent;
  let fixture: ComponentFixture<CreatingACharacterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatingACharacterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatingACharacterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
