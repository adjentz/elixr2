import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IItem, ISelectedItem } from '../../../models/view-models';
import { AppService } from '../../services/app.service';

@Component({
  selector: 'app-creature-equipment',
  templateUrl: './creature-equipment.component.html',
  styleUrls: ['./creature-equipment.component.less']
})
export class CreatureEquipmentComponent implements OnInit {

  @Input() selectedItems: ISelectedItem[];
  @Output() itemSelected = new EventEmitter<IChosenItem>();
  @Output() itemRemoved = new EventEmitter<ISelectedItem>();

  choosingItem = false;
  chosenItem: IChosenItem;
  selectedItemDetail: ISelectedItem;

  constructor(private appService: AppService) { }

  ngOnInit() {
  }

  cancelSlideout(): void {
    this.choosingItem = false;
    this.chosenItem = null;
    this.selectedItemDetail = null;
    this.appService.dismissSlideout();
  }
  chooseItem(): void {
    this.choosingItem = true;
    this.chosenItem = {
      applyCost: false,
      item: null
    };
    this.appService.showSlideout();
  }

  removeItem(): void {
    this.itemRemoved.emit(this.selectedItemDetail);
    this.cancelSlideout();
  }
  itemChosen(item: IItem): void {
    this.chosenItem.item = item;
  }

  viewDetail(selectedItem: ISelectedItem): void {
    this.selectedItemDetail = selectedItem;
  }

  confirmItem(): void {
    this.itemSelected.emit(this.chosenItem);
    this.cancelSlideout();
  }
}

export interface IChosenItem {
  item: IItem;
  applyCost: boolean;
}