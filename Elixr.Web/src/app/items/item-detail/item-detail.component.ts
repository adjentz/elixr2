import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IItem, IEquipment } from '../../../models/view-models';

@Component({
  selector: 'app-item-detail',
  templateUrl: './item-detail.component.html',
  styleUrls: ['../../shared-styles/game-element.less']
})
export class ItemDetailComponent implements OnInit {

  @Input() item;
  @Input() forSelection: boolean;
  @Output() itemSelected = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }
  formatCost(equipment: IEquipment): string {
    let parts: string[] = [];
    if (equipment.goldCost > 0) {
      parts.push(`${equipment.goldCost} GP`);
    }
    if (equipment.silverCost > 0) {
      parts.push(`${equipment.silverCost} SP`);
    }
    if (equipment.copperCost > 0) {
      parts.push(`${equipment.copperCost} CP`);
    }

    return parts.join(", ");
  }

  nameClicked(): void {
    this.itemSelected.emit();
  }
}
