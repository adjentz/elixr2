import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IArmor } from '../../../models/view-models';

@Component({
  selector: 'app-armor-detail',
  templateUrl: './armor-detail.component.html',
  styleUrls: ['../../shared-styles/game-element.less']
})
export class ArmorDetailComponent implements OnInit {

  @Input() armor;
  @Input() forSelection: boolean;
  @Output() armorSelected = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }
  formatCost(armor: IArmor): string {
    let parts: string[] = [];
    if (armor.goldCost > 0) {
      parts.push(`${armor.goldCost} GP`);
    }
    if (armor.silverCost > 0) {
      parts.push(`${armor.silverCost} SP`);
    }
    if (armor.copperCost > 0) {
      parts.push(`${armor.copperCost} CP`);
    }

    return parts.join(", ");
  }

  nameClicked(): void {
    this.armorSelected.emit();
    console.log("alpha");
    
  }
}
