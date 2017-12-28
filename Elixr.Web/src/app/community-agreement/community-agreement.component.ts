import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-community-agreement',
  templateUrl: './community-agreement.component.html',
  styleUrls: ['./community-agreement.component.css']
})
export class CommunityAgreementComponent implements OnInit {

  isFun = false;
  isBalanced = false;
  abidesToS = false;
  @Output() acceptedConditions = new EventEmitter<boolean>();

  constructor() { }

  ngOnInit() {
  }

  checkStatus(): void {
    let accepted = this.isFun && this.isBalanced && this.abidesToS;
    this.acceptedConditions.emit(accepted);
  }

}
