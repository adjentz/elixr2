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
  get totalPower(): number {
    return this.combatPower + this.presencePower + this.environmentPower;
  }
  get combatPower(): number {
    return this.characteristic.combatPower;
  }
  get environmentPower(): number {
    return this.characteristic.environmentPower;
  }
  get presencePower(): number {
    return this.characteristic.presencePower;
  }

  nameClicked(): void {
    if (!this.forSelection) {
      return;
    }

    this.selected.emit();
  }
}
