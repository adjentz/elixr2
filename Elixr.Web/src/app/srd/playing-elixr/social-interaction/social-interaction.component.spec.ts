import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SocialInteractionComponent } from './social-interaction.component';

describe('SocialInteractionComponent', () => {
  let component: SocialInteractionComponent;
  let fixture: ComponentFixture<SocialInteractionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SocialInteractionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SocialInteractionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
