import { Component, OnInit, Input } from '@angular/core';
import { ISelectedCharacteristic, CharacteristicType } from '../../../models/view-models';

@Component({
  selector: 'app-selected-characteristic-detail',
  templateUrl: './selected-characteristic-detail.component.html',
  styleUrls: ['./selected-characteristic-detail.component.css']
})
export class SelectedCharacteristicDetailComponent implements OnInit {

  @Input() selectedCharacteristic: ISelectedCharacteristic;
  constructor() { }

  ngOnInit() {
  }

  get characteristicType(): string {
    if(!this.selectedCharacteristic) {
      return "";
    }
    switch (this.selectedCharacteristic.characteristic.type) {
      case CharacteristicType.Feature:
        return "Feature";
      case CharacteristicType.Flaw:
        return "Flaw";
      case CharacteristicType.Oath:
        return "Oath";
      default:
        return "";
    }
  }
}
