import { Component, OnInit } from '@angular/core';
import { CharacteristicType } from '../../../../models/view-models';
@Component({
  selector: 'app-flaws',
  templateUrl: './flaws.component.html',
  styleUrls: ['./flaws.component.css']
})
export class FlawsComponent implements OnInit {

  flaws = CharacteristicType.Flaw;
  constructor() { }

  ngOnInit() {
  }

}
