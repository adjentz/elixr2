import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CommunityAgreementComponent } from './community-agreement.component';

describe('CommunityAgreementComponent', () => {
  let component: CommunityAgreementComponent;
  let fixture: ComponentFixture<CommunityAgreementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CommunityAgreementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CommunityAgreementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
