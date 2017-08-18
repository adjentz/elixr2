import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ISpell } from '../../../models/view-models';

@Component({
  selector: 'app-spell-detail',
  templateUrl: './spell-detail.component.html',
  styleUrls: ['../../shared-styles/game-element.less']
})
export class SpellDetailComponent implements OnInit {

  @Input() spell;
  @Input() forSelection: boolean;
  @Output() spellSelected = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  nameClicked(): void {
    this.spellSelected.emit();
  }
}
