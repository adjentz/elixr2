import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { AppService } from '../../services/app.service';
import { ElixrService } from '../../services/elixr.service';
import { IWeapon, ISelectedWeapon, WeaponUseAbility, IAppliedStatMod } from '../../../models/view-models';

@Component({
  selector: 'app-creature-attacks',
  templateUrl: './creature-attacks.component.html',
  styleUrls: ['./creature-attacks.component.less', '../creature-sources.less']
})
export class CreatureAttacksComponent implements OnInit {

  choosingWeapon = false;
  chosenWeapon: IChosenWeapon;
  selectedWeaponDetail: ISelectedWeapon;
  @Input() selectedWeapons: ISelectedWeapon[];
  @Input() allAppliedStatMods: IAppliedStatMod[];
  @Output() weaponSelected = new EventEmitter<IChosenWeapon>();
  @Output() weaponRemoved = new EventEmitter<ISelectedWeapon>();
  constructor(private appService: AppService, private elixrService: ElixrService) { }

  ngOnInit() {
  }

  chooseWeapon(): void {
    this.choosingWeapon = true;
    this.chosenWeapon = {
      applyCost: false,
      weapon: null
    };
    this.appService.showSlideout();
  }
  cancelSlideout(): void {
    this.choosingWeapon = false;
    this.chosenWeapon = null;
    this.selectedWeaponDetail = null;
    this.appService.dismissSlideout();
  }
  weaponChosen(weapon: IWeapon) {
    this.chosenWeapon.weapon = weapon;
  }

  private formatUseAbility(useAbility: WeaponUseAbility): string {
    switch (useAbility) {
      case WeaponUseAbility.Strength:
        return "Strength";
      case WeaponUseAbility.Agility:
        return "Agility";
      case WeaponUseAbility.Focus:
        return "Focus";
      case WeaponUseAbility.Charm:
        return "Charm";
      case WeaponUseAbility.None:
        return "None";
    }
  }
  formatAttackForWeapon(selectedWeapon: ISelectedWeapon): string {
    let abilityName = this.formatUseAbility(selectedWeapon.weapon.attackAbility);
    let abilityBonus = this.elixrService.getAbilityBonus(abilityName, this.allAppliedStatMods.map(asm => asm.statMod));

    selectedWeapon.appliedCharacteristics.map(ac => ac.characteristic.attackBonusMod).forEach(abm => abilityBonus += abm);

    if (abilityBonus > 0) {
      return "+" + abilityBonus;
    }
    return abilityBonus.toString(); //Will include negative sign 
  }
  formatDamageForWeapon(selectedWeapon: ISelectedWeapon): string {
    let weapon = selectedWeapon.weapon;
    let abilityName = this.formatUseAbility(weapon.damageAbility);
    let abilityBonus = this.elixrService.getAbilityBonus(abilityName, this.allAppliedStatMods.map(asm => asm.statMod));

    let characteristicDamageBonusSum = 0;
    selectedWeapon.appliedCharacteristics.forEach(ac => characteristicDamageBonusSum += ac.characteristic.damageBonusMod)

    let bonus = abilityBonus + characteristicDamageBonusSum;
    let bonusIsPositive = bonus > 0;
    let sign = bonusIsPositive ? "+" : "-";
    bonus = Math.abs(bonus);

    let characteristicExtraDamages = selectedWeapon.appliedCharacteristics.filter(ac => ac.characteristic.extraDamage && ac.characteristic.extraDamage.length > 0).map(ac => ac.characteristic.extraDamage);
    return `${weapon.damage} + ${characteristicExtraDamages.join(" + ")} ${sign} ${bonus}`;
  }
  formatRangeForWeapon(weapon: IWeapon): string {
    if (weapon.range > 0) {
      return weapon.range + "ft";
    }
    return "--";
  }
  viewDetail(selectedWeapon: ISelectedWeapon): void {
    this.selectedWeaponDetail = selectedWeapon;
    this.appService.showSlideout();
  }
  removeSelectedWeapon(): void {
    this.weaponRemoved.emit(this.selectedWeaponDetail);
    this.cancelSlideout();
  }
  confirmWeapon(): void {
    this.weaponSelected.emit(this.chosenWeapon);
    this.cancelSlideout();
  }
}

export interface IChosenWeapon {
  weapon: IWeapon;
  applyCost: boolean;
}
