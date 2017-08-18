import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ElixrService } from '../../services/elixr.service';
import { AppService } from '../../services/app.service';
import { IAppliedStatMod, IStatMod, ISelectedArmor, IArmor } from '../../../models/view-models';


@Component({
  selector: 'app-creature-defense',
  templateUrl: './creature-defense.component.html',
  styleUrls: ['./creature-defense.component.less', '../creature-sources.less']
})
export class CreatureDefenseComponent implements OnInit {

  @Input() allAppliedStatMods: IAppliedStatMod[];
  @Input() selectedArmor: ISelectedArmor[];
  @Input() baseDefense: number;
  @Output() armorSelected = new EventEmitter<IChosenArmor>();
  @Output() armorRemoved = new EventEmitter<ISelectedArmor>();

  choosingArmor = false;
  payForArmor = false;
  chosenArmor: IChosenArmor;
  selectedArmorDetail: ISelectedArmor;
  constructor(private elixrService: ElixrService, private appService: AppService) { }

  ngOnInit() {
  }

  get defenseSources(): IStatMod[] {
    let result = this.allAppliedStatMods.sort((lhs, rhs) => lhs.appliedAtUnixMS - rhs.appliedAtUnixMS)
      .map(asm => asm.statMod)
      .filter(sm => sm.stat.name === "Defense");
    return result;
  }

  get agilityBonus(): number {
    return this.elixrService.getAbilityBonus("Agility", this.allAppliedStatMods.map(asm => asm.statMod));
  }
  get totalDefense(): number {
    let bonusFromStatMods = this.elixrService.sumStatMods(this.allAppliedStatMods.map(asm => asm.statMod), "Defense");
    let armorBonus = 0;
    if (this.selectedArmor) {
      this.selectedArmor.map(sa => sa.armor).forEach(a => armorBonus += a.defenseBonus);
    }
    return bonusFromStatMods + this.agilityBonus + armorBonus + this.baseDefense;
  }

  addArmor(): void {
    this.choosingArmor = true;
    this.chosenArmor = {
      applyCost: false,
      armor: null
    };
    this.appService.showSlideout();
  }
  armorChosen(armor: IArmor): void {
    this.chosenArmor.armor = armor;
  }
  viewDetail(selectedArmor: ISelectedArmor): void {
    this.selectedArmorDetail = selectedArmor;
    this.appService.showSlideout();
  }
  confirmArmor(): void {
    this.armorSelected.emit(this.chosenArmor);
    this.cancelSlideout();
  }

  removeArmor(): void {
    this.armorRemoved.emit(this.selectedArmorDetail);
    this.cancelSlideout();
  }

  cancelSlideout(): void {
    this.choosingArmor = false;
    this.chosenArmor = null;
    this.selectedArmorDetail = null;
    this.appService.dismissSlideout();
  }

}

export interface IChosenArmor {
  armor: IArmor;
  applyCost: boolean;
}