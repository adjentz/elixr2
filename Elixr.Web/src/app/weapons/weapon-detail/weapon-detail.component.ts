import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IWeapon, WeaponUseAbility } from '../../../models/view-models';

@Component({
  selector: 'app-weapon-detail',
  templateUrl: './weapon-detail.component.html',
  styleUrls: ['../../shared-styles/game-element.less']
})
export class WeaponDetailComponent implements OnInit {

  @Input() weapon: IWeapon;
  @Input() forSelection: boolean;
  @Output() selected = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }
  nameClicked(): void {
    this.selected.emit();
  }

  private formatUseAbility(useAblity:WeaponUseAbility):string {
    switch (useAblity) {
      case WeaponUseAbility.Strength:
        return "Strength";
      case WeaponUseAbility.Agility:
        return "Agility";
      case WeaponUseAbility.Focus:
        return "Focus";
    }
  }
  get attackAbility(): string {
    return this.formatUseAbility(this.weapon.attackAbility);
  }
  get damageAbility(): string {
    return this.formatUseAbility(this.weapon.damageAbility);
  }
}
