import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { IItem, IEquipment } from '../../models/view-models';
import { ItemService } from '../services/items.service';
import { AppService } from '../services/app.service';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

  @Input() forSelection:boolean;
  @Output() itemSelected = new EventEmitter<IItem>();
  items:IItem[];
  detailItem: IItem;

  constructor(private itemService: ItemService, private appService: AppService) { }

  ngOnInit() {
    this.searchItems();
  }

  async searchItems() {
    this.items = await this.itemService.searchItems();
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

  viewDetail(item: IItem): void {
    console.log(item);
    this.detailItem = item;
    this.appService.showSlideout();
  }
  cancelSlideout(): void {
    this.detailItem = null;
    if(!this.forSelection) {
      this.appService.dismissSlideout();
    }
  }

  itemChosen(item:IItem):void {
    this.itemSelected.emit(item);
  }
}