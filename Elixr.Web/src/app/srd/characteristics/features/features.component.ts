import { Component, OnInit } from '@angular/core';
import { CharacteristicType } from '../../../../models/view-models';
@Component({
  selector: 'app-features',
  templateUrl: './features.component.html',
  styleUrls: ['./features.component.css']
})
export class FeaturesComponent implements OnInit {

  features = CharacteristicType.Feature;
  constructor() { }

  ngOnInit() {
  }

}
