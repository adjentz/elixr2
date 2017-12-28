import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { WeaponService } from '../services/weapons.service';
import { AppService } from '../services/app.service';
import { IWeapon, WeaponUseAbility, ISelectedWeapon } from '../../models/view-models';

@Component({
  selector: 'app-weapons',
  templateUrl: './weapons.component.html',
  styleUrls: ['./weapons.component.css']
})
export class WeaponsComponent implements OnInit {

  weaponGroups: { [group: string]: IWeapon[] }
  detailWeapon:IWeapon;

  @Input() forSelection: boolean;
  @Output() weaponSelected = new EventEmitter<IWeapon>();

  constructor(private weaponsService: WeaponService, private appService:AppService) { }

  ngOnInit() {
    this.searchWeapons();
  }

  async searchWeapons() {
    this.weaponGroups = {};
    this.weaponGroups["One-Handed"] = [];
    this.weaponGroups["Two-Handed"] = [];
    this.weaponGroups["Ranged"] = [];

    let weapons = await this.weaponsService.searchWeapons();
    weapons = weapons.sort((lhs, rhs) => lhs.name.localeCompare(rhs.name));
    weapons.forEach(w => this.placeWeaponInGroup(w));
  }

  private placeWeaponInGroup(weapon: IWeapon): void {
    if (weapon.range > 0) {
      this.weaponGroups["Ranged"].push(weapon);
    }
    else if (weapon.defaultCharacteristics.findIndex(dc => dc.characteristic.name.toLowerCase() === 'two-handed') > -1) {
      this.weaponGroups["Two-Handed"].push(weapon);
    }
    else {
      this.weaponGroups["One-Handed"].push(weapon);
    }
  }

  formatRange(weapon: IWeapon): string {
    if (weapon.range <= 0) {
      return "--";
    }
    return `${weapon.range} ft.`;
  }

  formatCost(weapon: IWeapon): string {
    let parts: string[] = [];
    if (weapon.goldCost > 0) {
      parts.push(`${weapon.goldCost} GP`);
    }
    if (weapon.silverCost > 0) {
      parts.push(`${weapon.silverCost} SP`);
    }
    if (weapon.copperCost > 0) {
      parts.push(`${weapon.copperCost} CP`);
    }
    return parts.join(", ");
  }

  private formatUseAbility(useAbility: WeaponUseAbility): string {
    switch (useAbility) {
      case WeaponUseAbility.Strength:
        return "Strength";
      case WeaponUseAbility.Agility:
        return "Agility";
      case WeaponUseAbility.Focus:
        return "Focus";
    }
  }

  getWeaponCharacteristics(weapon: IWeapon): string {
    return weapon.defaultCharacteristics.map(dc => dc.characteristic.name).join(', ');
  }

  formatAttack(weapon: IWeapon): string {
    return this.formatUseAbility(weapon.attackAbility);
  }
  formatDamageAbility(weapon: IWeapon): string {
    return `${this.formatUseAbility(weapon.damageAbility)}`;
  }

  weaponChosen(weapon: IWeapon) {
    this.detailWeapon = null;
    this.weaponSelected.emit(weapon);
  }

  viewDetail(weapon:IWeapon):void {
    if(this.forSelection) {
      this.weaponChosen(weapon);
      return;
    }
    this.detailWeapon = weapon;
    this.appService.showSlideout();
  }
  cancelDetail():void {
    this.detailWeapon = null;
    if(!this.forSelection) {
      this.appService.dismissSlideout();
    }
  }

  get weaponGroupKeys(): string[] {
    return Object.keys(this.weaponGroups);
  }
}

