import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ISelectedCharacteristic, ICharacteristic, CharacteristicType, ICampaignSetting, IAppliedStatMod, ISelectedTemplate } from '../../../models/view-models';
import { AppService } from '../../services/app.service';
import { ElixrService } from '../../services/elixr.service';

@Component({
  selector: 'app-creature-characteristics',
  templateUrl: './creature-characteristics.component.html',
  styleUrls: ['./creature-characteristics.component.less']
})
export class CreatureCharacteristicsComponent implements OnInit {



  viewingDetail = false;
  detailSelectedCharacteristic: ISelectedCharacteristic;

  @Input() allAppliedStatMods: IAppliedStatMod[];
  @Input() selectedCharacteristics: ISelectedCharacteristic[];
  @Input() selectedTemplates: ISelectedTemplate[];
  @Input() level:number;
  @Input() isCharacter:boolean;
  @Input() setting:ICampaignSetting;
  @Output() characteristicSelected = new EventEmitter<ICharacteristic>();
  @Output() characteristicRemoved = new EventEmitter<ISelectedCharacteristic>();

  getCharacteristicType = CharacteristicType.Other;
  gettingCharacteristic = false;


  constructor(private appService: AppService, private elixrService: ElixrService) { }

  ngOnInit() {
  }

  viewDetails(selectedCharacteristic: ISelectedCharacteristic): void {
    this.detailSelectedCharacteristic = selectedCharacteristic;
    this.viewingDetail = true;

    this.showSlideout();
  }

  getCharacteristicsInType(type: CharacteristicType) {
    if (!this.selectedCharacteristics) {
      return null;
    }
    let result: ISelectedCharacteristic[] = [];
    for (let charSet of this.selectedTemplates.map(st => st.template.appliedCharacteristics)) {
      result = result.concat(charSet.filter(sc => sc.characteristic.type === type));
    }
    result = result.concat(this.selectedCharacteristics.filter(tc => tc.characteristic.type === type));
    return result.sort((lhs, rhs) => {
      if (lhs.takenAtMS > rhs.takenAtMS) {
        return 1;
      }
      if (lhs.takenAtMS < rhs.takenAtMS) {
        return -1;
      }
      return lhs.characteristic.name.localeCompare(rhs.characteristic.name);
    })
  }
  get features(): ISelectedCharacteristic[] {
    return this.getCharacteristicsInType(CharacteristicType.Feature);
  }
  get flaws(): ISelectedCharacteristic[] {
    return this.getCharacteristicsInType(CharacteristicType.Flaw);
  }
  get oaths(): ISelectedCharacteristic[] {
    return this.getCharacteristicsInType(CharacteristicType.Oath);
  }
  get shouldShowPointsRemaining():boolean {
    return this.isCharacter;
  }
  get shouldShowSlideout(): boolean {
    return this.getCharacteristicType !== CharacteristicType.Other;
  }
  get characteristicPointsRemaining(): number {
    let costSum = 0;
    this.selectedCharacteristics.forEach(sc => costSum += this.elixrService.getCharacteristicPower(sc.characteristic));
    let pointsForLevel = this.setting.characteristicPointsEachLevel * this.level;
    return pointsForLevel - costSum;
  }

  showSlideout(): void {
    this.appService.showSlideout();
  }
  cancelSlideout(): void {
    this.getCharacteristicType = CharacteristicType.Other;
    this.viewingDetail = false;
    this.detailSelectedCharacteristic = null;
    this.appService.dismissSlideout();
  }
  addFeature(): void {
    this.getCharacteristicType = CharacteristicType.Feature;
    this.showSlideout();
  }
  addFlaw(): void {
    this.getCharacteristicType = CharacteristicType.Flaw;
    this.showSlideout();
  }
  addOath(): void {
    this.getCharacteristicType = CharacteristicType.Oath;
    this.showSlideout();
  }

  get typeName(): string {
    switch (this.getCharacteristicType) {
      case CharacteristicType.Feature:
        return "Feature";
      case CharacteristicType.Flaw:
        return "Flaw";
      case CharacteristicType.Oath:
        return "Oath";
      default:
        return "";
    }
  }

  characteristicChosen(characteristic: ICharacteristic): void {

    this.characteristicSelected.emit(characteristic);
    this.cancelSlideout();
  }
  removeCharacteristic(): void {
    if (!this.detailSelectedCharacteristic) {
      return;
    }

    this.characteristicRemoved.emit(this.detailSelectedCharacteristic);
    this.cancelSlideout();
  }

  get detailIsTemplateCharacteristic(): boolean {
    return this.selectedCharacteristics.findIndex(sc => sc.selectedCharacteristicId === this.detailSelectedCharacteristic.selectedCharacteristicId) < 0;
  }
}
