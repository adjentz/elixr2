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
    else if (weapon.isTwoHanded) {
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

  getWeaponAttributes(weapon: IWeapon): string {
    let attrs = "";

    if (weapon.canBludgeon) {
      attrs += "B";
    }
    if (weapon.canPierce) {
      attrs += "P";
    }
    if (weapon.canSlash) {
      attrs += "S";
    }
    if (weapon.hasReach) {
      attrs += "R";
    }
    if (attrs.length > 0) {
      return "[" + attrs + "]";
    }
    return "--";
  }

  formatAttack(weapon: IWeapon): string {
    return this.formatUseAbility(weapon.attackAbility) + " Bonus";
  }
  formatDamage(weapon: IWeapon): string {
    return `${weapon.damage} + ${this.formatUseAbility(weapon.damageAbility)} Bonus`;
  }

  weaponChosen(weapon: IWeapon) {
    this.detailWeapon = null;
    this.weaponSelected.emit(weapon);
  }

  viewDetail(weapon:IWeapon):void {
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

