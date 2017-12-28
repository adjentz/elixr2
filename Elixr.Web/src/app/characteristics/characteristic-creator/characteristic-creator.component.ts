import { Component, OnInit, Input } from '@angular/core';
import { IStat, IStatMod, ICharacteristic, CharacteristicType } from '../../../models/view-models';
import { ApiService } from '../../services/api.service';
import { ElixrService } from '../../services/elixr.service';

@Component({
  selector: 'app-characteristic-creator',
  templateUrl: './characteristic-creator.component.html',
  styleUrls: ['./characteristic-creator.component.less', '../../shared-styles/game-element.less']
})
export class CharacteristicCreatorComponent implements OnInit {

  acceptedConditions = false;
  currentStatMod: IStatMod;
  statMods: IStatMod[];
  moddableStats: IStat[];
  loading = false;
  useSuggestedPower = true;
  error = '';
  title = '';
  description = '';
  specifiedPower = 0;
  explainCharacteristicTypes = false;
  @Input() suggestedType: CharacteristicType;
  selectedType: CharacteristicType;

  characteristicTypes: CharacteristicType[];

  constructor(private apiService: ApiService, private elixrService: ElixrService) {
    this.statMods = [];
    this.characteristicTypes = [CharacteristicType.Feature, CharacteristicType.Flaw, CharacteristicType.Oath];
  }

  async ngOnInit() {
    this.loading = true;
    this.moddableStats = await this.apiService.get<IStat[]>('stats/moddable');
    this.resetCurrentStatMod();
    this.loading = false;
    this.selectedType = this.suggestedType || CharacteristicType.Feature;
  }
  private resetCurrentStatMod(): void {
    this.currentStatMod = {
      modifier: 0,
      reason: '',
      stat: this.moddableStats[0],
      statId: this.moddableStats[0].statId,
      statModId: -1
    };
  }

  modIsValid(statMod: IStatMod): boolean {
    if (this.currentStatMod.modifier % this.currentStatMod.stat.ratio !== 0) {
      let stat = this.currentStatMod.stat;
      this.error = `${stat.displayName || stat.name} modifier must be in steps of ${stat.ratio}`;
      return false;
    }
    return true;
  }
  addMod(): void {
    this.statMods.push(this.currentStatMod);
    this.resetCurrentStatMod();
  }

  get totalSuggestedPower(): number {
    if (this.loading) {
      return 0;
    }
    let sum = 0;
    let statMods = [...this.statMods];
    if (this.currentStatMod.modifier !== 0) {
      statMods.push(this.currentStatMod);
    }
    statMods.forEach(sm => sum += this.elixrService.getStatModPower(sm));
    return sum;
  }

  async submit(): Promise<void> {
    let statMods = [...this.statMods];
    if (this.currentStatMod.modifier !== 0) {
      statMods.push(this.currentStatMod);
    }
    let anyInvalid = statMods.findIndex(sm => !this.modIsValid(sm)) > -1;
    if (anyInvalid) {
      return;
    }
    if (!this.acceptedConditions) {
      this.error = "Must agree to conditions";
      return;
    }

    statMods.forEach(sm => sm.reason = `Characteristic: ${this.title}`);

    // let characteristic: ICharacteristic = {
    //   id: -1,
    //   mods: statMods,
    //   name: this.title,
    //   specifiedPowerAdjustment: this.useSuggestedPower ? null : this.specifiedPower,
    //   type: this.selectedType,
    //   description: this.description,
    //   authorId: -1,
    //   campaignSettingId: -1
    // };
    // console.log(characteristic);
  }
  currentStatModChanged() {
    this.currentStatMod.modifier = 0;
  }
  clearError(): void {
    this.error = '';
  }

  updateAcceptedConditions(accepted: boolean): void {
    this.acceptedConditions = accepted;
    this.error = null;
  }

  removeMod(statMod: IStatMod): void {
    let index = this.statMods.indexOf(statMod);
    this.statMods.splice(index, 1);
  }
}
