import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { ElixrService } from '../../services/elixr.service';
import { AppService } from '../../services/app.service';
import { IAppliedStatMod, ICreature, ITemplate, ICampaignSetting, ISelectedArmor, ISelectedTemplate } from '../../../models/view-models';

@Component({
  selector: 'app-creature-description',
  templateUrl: './creature-description.component.html',
  styleUrls: ['./creature-description.component.less']
})
export class CreatureDescriptionComponent implements OnInit {

  @Input() allAppliedStatMods: IAppliedStatMod[];
  @Input() setting: ICampaignSetting;
  @Input() selectedArmor: ISelectedArmor[];
  @Output() leveledUp = new EventEmitter();
  @Output() leveledDown = new EventEmitter();
  @Output() portraitChanged = new EventEmitter<File>();
  @Output() templateSelected = new EventEmitter<ITemplate>();
  @Output() templateRemoved = new EventEmitter<ISelectedTemplate>();
  @Input() creature: ICreature;
  @ViewChild("fileInput") fileInput: ElementRef;

  portraitDataUrl = "";
  settingImage = false;
  selectingTemplate = false;
  explainingRaceTemplates = false;
  detailTemplate: ISelectedTemplate;

  constructor(private statModsService: ElixrService, private appService: AppService) { }

  ngOnInit() {
  }

  levelUp() {
    this.leveledUp.emit();
  }
  levelDown() {
    this.leveledDown.emit();
  }
  get speed(): number {
    if (!this.setting) {
      return 0;
    }
    let armorPenalty = 0;
    if (this.selectedArmor) {
      this.selectedArmor.map(sa => sa.armor.speedPenalty).forEach(sp => armorPenalty += sp);
    }
    return this.statModsService.sumStatMods(this.allAppliedStatMods.map(asm => asm.statMod), "Speed") - armorPenalty;
  }
  //Physical descriptions
  get name(): string {
    if (!this.creature) {
      return "";
    }
    return this.creature.name;
  }
  set name(value: string) {
    this.creature.name = value;
  }

  get age(): string {
    if (!this.creature) {
      return "";
    }
    return this.creature.age;
  }
  set age(value: string) {
    this.creature.age = value;
  }

  get gender(): string {
    if (!this.creature) {
      return "";
    }
    return this.creature.gender;
  }
  set gender(value: string) {
    this.creature.gender = value;
  }

  get description(): string {
    if (!this.creature) {
      return "";
    }
    return this.creature.description;
  }
  set description(value: string) {
    this.creature.description = value;
  }

  get hair(): string {
    if (!this.creature) {
      return "";
    }
    return this.creature.hair;
  }
  set hair(value: string) {
    this.creature.hair = value;
  }

  get skin(): string {
    if (!this.creature) {
      return "";
    }
    return this.creature.skin;
  }
  set skin(value: string) {
    this.creature.skin = value;
  }

  get height(): string {
    if (!this.creature) {
      return "";
    }
    return this.creature.height;
  }
  set height(value: string) {
    this.creature.height = value;
  }

  get weight(): string {
    if (!this.creature) {
      return "";
    }
    return this.creature.weight;
  }
  set weight(value: string) {
    this.creature.weight = value;
  }

  get eyes(): string {
    if (!this.creature) {
      return "";
    }
    return this.creature.eyes;
  }
  set eyes(value: string) {
    this.creature.eyes = value;
  }

  get hasPortrait(): boolean {
    if (!this.portraitDataUrl) {
      return false;
    }
    return true;
  }
  get portraitSrc(): string {

    if (!this.hasPortrait) {
      return "none";
    }
    return `url(${this.portraitDataUrl})`;
  }

  get power(): number {
    if (!(this.setting && this.creature)) {
      return 0;
    }

    return this.statModsService.getCreaturePower(this.creature);
  }
  changePortrait(): void {
    this.fileInput.nativeElement.click();
  }

  portraitChange(): void {
    let fileInput: HTMLInputElement = this.fileInput.nativeElement;
    let file = fileInput.files[0];
    this.portraitChanged.emit(file);
    let reader = new FileReader();
    this.settingImage = true;
    reader.onload = () => {
      this.portraitDataUrl = reader.result;
      this.settingImage = false;
    };
    reader.readAsDataURL(file);
  }

  chooseTemplate(): void {
    this.selectingTemplate = true;
    this.appService.showSlideout();
  }
  templateChosen(template: ITemplate): void {
    this.templateSelected.emit(template);
    this.cancelSlideout();
  }
  removeTemplate(selectedTemplate: ISelectedTemplate): void {
    this.templateRemoved.emit(selectedTemplate);
    this.cancelSlideout();
  }
  viewTemplateDetail(template: ISelectedTemplate) {
    this.detailTemplate = template;
    this.appService.showSlideout();
  }
  cancelSlideout(): void {
    this.selectingTemplate = false;
    this.explainingRaceTemplates = false;
    this.detailTemplate = null;
    this.appService.dismissSlideout();
  }
  explainRaceTemplates(): void {
    this.explainingRaceTemplates = true;
  }

  get defaultRaceTemplateText(): string {
    if (!this.creature || this.creature.selectedTemplates.length === 0) {
      return "[self]";
    }

    return "Add"
  }
}
