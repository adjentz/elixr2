import { Component, OnInit, Input } from '@angular/core';
import { IWeaponCharacteristic } from '../../../models/view-models';

@Component({
  selector: 'app-weapons-characteristic',
  templateUrl: './weapons-characteristic.component.html',
  styleUrls: ['./weapons-characteristic.component.css', '../../shared-styles/game-element.less']
})
export class WeaponsCharacteristicComponent implements OnInit {

  private val: IWeaponCharacteristic;
  @Input() get characteristic(): IWeaponCharacteristic { return this.val };
  set characteristic(value: IWeaponCharacteristic) { this.val = value; console.log(value); }
  constructor() { }

  ngOnInit() {
  }

}
