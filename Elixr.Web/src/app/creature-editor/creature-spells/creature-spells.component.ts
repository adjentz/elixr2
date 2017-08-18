import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ISelectedSpell, ISpell, ISelectedTemplate } from '../../../models/view-models';
import { AppService } from '../../services/app.service';

@Component({
  selector: 'app-creature-spells',
  templateUrl: './creature-spells.component.html',
  styleUrls: ['./creature-spells.component.less']
})
export class CreatureSpellsComponent implements OnInit {

  @Input() selectedSpells: ISelectedSpell[];
  @Input() selectedTemplates: ISelectedTemplate[];
  @Input() isCharacter:boolean;
  @Output() spellSelected = new EventEmitter<ISpell>();
  @Output() spellRemoved = new EventEmitter<ISelectedSpell>();

  learningSpell = false;
  selectedSpellDetail: ISelectedSpell;
  constructor(private appService: AppService) { }

  ngOnInit() {
  }

  get shouldShowPowerCostNote():boolean {
    return this.isCharacter;
  }
  cancelSlideout(): void {
    this.learningSpell = false;
    this.selectedSpellDetail = null;
    this.appService.dismissSlideout();
  }
  learnSpell() {
    this.learningSpell = true;
    this.appService.showSlideout();
  }
  spellLearned(spell: ISpell): void {
    this.spellSelected.emit(spell);
    this.cancelSlideout();
  }

  private get templateSpells(): ISelectedSpell[] {
    if (!this.selectedTemplates) {
      return [];
    }
    let templateSpellCollections = this.selectedTemplates.map(st => st.template.selectedSpells);
    if (templateSpellCollections.length > 0) {
      return templateSpellCollections.reduce((acc, cur) => acc.concat(cur));
    }
    return [];
  }
  get allSelectedSpells(): ISelectedSpell[] {
    if (!this.selectedSpells) {
      return null;
    }
    return this.templateSpells.concat(this.selectedSpells);
  }

  isTemplateSpell(selectedSpell: ISelectedSpell): boolean {
    return this.templateSpells.findIndex(ts => ts.selectedSpellId === selectedSpell.selectedSpellId) > -1;
  }

  removeSpell(): void {
    this.spellRemoved.emit(this.selectedSpellDetail);
    this.cancelSlideout();
  }

  viewDetail(selectedSpell: ISelectedSpell): void {
    this.selectedSpellDetail = selectedSpell;
    this.appService.showSlideout();
  }
}
