import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CharacteristicType, ICharacteristic } from '../../models/view-models';
import { CharacteristicService } from '../services/characteristics.service';

@Component({
  selector: 'app-characteristics',
  templateUrl: './characteristics.component.html',
  styleUrls: ['./characteristics.component.css']
})
export class CharacteristicsComponent implements OnInit {

  @Input() type: CharacteristicType;
  @Input() forSelection: boolean;
  @Output() selected = new EventEmitter<ICharacteristic>();

  characteristics: ICharacteristic[];
  filterName = "";

  constructor(private characteristicsService: CharacteristicService) { }

  ngOnInit() {
    this.search();
  }

  async search() {
    this.characteristics = await this.characteristicsService.searchCharacteristics(this.type, this.filterName);
  }

  get formatType(): string {
    switch (this.type) {
      case CharacteristicType.Feature:
        return "Feature";
      case CharacteristicType.Flaw:
        return "Flaw";
      case CharacteristicType.Oath:
        return "Oath";
    }
  }

  characteristicSelected(characteristic: ICharacteristic): void {
    if (!this.forSelection) {
      return;
    }
    this.selected.emit(characteristic);
  }
}
