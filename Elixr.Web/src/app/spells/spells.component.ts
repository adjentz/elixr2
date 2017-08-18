import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { ISpell } from '../../models/view-models';
import { SpellsService } from '../services/spells.service';
import { AppService } from '../services/app.service';

@Component({
  selector: 'app-spells',
  templateUrl: './spells.component.html',
})
export class SpellsComponent implements OnInit {

  @Input() forSelection: boolean;
  @Output() spellSelected = new EventEmitter<ISpell>();
  spells: ISpell[];

  constructor(private spellsService: SpellsService, private appService: AppService) { }

  ngOnInit() {
    this.searchItems();
  }

  async searchItems() {
    this.spells = await this.spellsService.searchSpells();
  }


  spellChosen(spell: ISpell): void {
    this.spellSelected.emit(spell);
  }
}