import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacteristicCreatorComponent } from './characteristic-creator.component';

describe('CharacteristicCreatorComponent', () => {
  let component: CharacteristicCreatorComponent;
  let fixture: ComponentFixture<CharacteristicCreatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CharacteristicCreatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CharacteristicCreatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
