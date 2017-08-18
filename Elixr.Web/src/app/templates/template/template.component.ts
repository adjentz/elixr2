import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ITemplate, ICharacteristic, CharacteristicType, ISelectedCharacteristic } from '../../../models/view-models';
import { AppService } from '../../services/app.service';
import { ElixrService } from '../../services/elixr.service';

@Component({
  selector: 'app-template',
  templateUrl: './template.component.html',
  styleUrls: ['../../shared-styles/game-element.less']
})
export class TemplateComponent implements OnInit {

  @Input() forSelection: boolean;
  @Input() template: ITemplate;
  @Output() selected = new EventEmitter();

  selectedCharacteristicDetail: ISelectedCharacteristic;

  constructor(private appService: AppService, private elixrService:ElixrService) { }

  ngOnInit() {
  }

  get power():number {
    return this.elixrService.getTemplatePower(this.template);
  }
  get hasMods(): boolean {
    if (!this.template) {
      return false;
    }
    return this.template.mods.length > 0;
  }
  get hasFlaws(): boolean {
    let flaws = this.flaws;
    return flaws && flaws.length > 0;
  }
  get hasFeatures(): boolean {
    let features = this.features;
    return features && features.length > 0;
  }
  get features(): ISelectedCharacteristic[] {
    if (!this.template) {
      return null;
    }
    return this.template.appliedCharacteristics.filter(tc => tc.characteristic.type === CharacteristicType.Feature)
      .sort((lhs, rhs) => lhs.characteristic.name.localeCompare(rhs.characteristic.name));
  }
  get flaws(): ISelectedCharacteristic[] {
    if (!this.template) {
      return null;
    }
    return this.template.appliedCharacteristics.filter(tc => tc.characteristic.type === CharacteristicType.Flaw)
      .sort((lhs, rhs) => lhs.characteristic.name.localeCompare(rhs.characteristic.name));
  }

  viewSelectedCharacteristicDetail(selectedCharacteristic: ISelectedCharacteristic): void {

    this.appService.showSlideout();
    this.selectedCharacteristicDetail = selectedCharacteristic;
  }
  cancelSlideout(): void {

    this.selectedCharacteristicDetail = null;
    if(!this.forSelection){
      this.appService.dismissSlideout();
    }
  }
  nameClicked(): void {
    if(!this.forSelection) {
      return;
    }
    this.selected.emit();
  }

  notes(selectedCharacteristic: ISelectedCharacteristic): string {
    if (selectedCharacteristic.notes && selectedCharacteristic.notes.length > 0) {
      return `(${selectedCharacteristic.notes})`;
    }
    return "";
  }
}
