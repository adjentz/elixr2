import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectedCharacteristicDetailComponent } from './selected-characteristic-detail.component';

describe('SelectedCharacteristicDetailComponent', () => {
  let component: SelectedCharacteristicDetailComponent;
  let fixture: ComponentFixture<SelectedCharacteristicDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectedCharacteristicDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectedCharacteristicDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
