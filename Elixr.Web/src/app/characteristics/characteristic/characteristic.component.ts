import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ICharacteristic } from '../../../models/view-models';
import { ElixrService } from '../../services/elixr.service';

@Component({
  selector: 'app-characteristic',
  templateUrl: './characteristic.component.html',
  styleUrls: ['../../shared-styles/game-element.less']
})
export class CharacteristicComponent implements OnInit {
  @Input() characteristic: ICharacteristic;
  @Input() forSelection: boolean;
  @Output() selected = new EventEmitter();
  constructor(private elixrService: ElixrService) {

  }

  ngOnInit() {
  }

  get hasMods(): boolean {
    return this.characteristic.mods.length > 0;
  }
  get power(): number {
    return this.characteristic.combatPower + this.characteristic.presencePower + this.characteristic.environmentPower;
  }

  nameClicked(): void {
    if (!this.forSelection) {
      return;
    }

    this.selected.emit();
  }
}
