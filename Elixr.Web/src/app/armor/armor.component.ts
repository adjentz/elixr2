import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { IArmor } from '../../models/view-models';
import { ArmorService } from '../services/armor.service';
import { AppService } from '../services/app.service';

@Component({
  selector: 'app-armor',
  templateUrl: './armor.component.html',
  styleUrls: ['./armor.component.css']
})
export class ArmorComponent implements OnInit {

  @Input() forSelection:boolean;
  @Output() armorSelected = new EventEmitter<IArmor>();

  armorGroups: { [group: string]: IArmor[] }
  detailArmor: IArmor;

  constructor(private armorService: ArmorService, private appService: AppService) { }

  ngOnInit() {
    this.armorGroups = {};
    this.armorGroups["Light"] = [];
    this.armorGroups["Medium"] = [];
    this.armorGroups["Heavy"] = [];

    this.searchArmor();
  }

  async searchArmor() {
    let armor = await this.armorService.searchArmor();
    armor.forEach(a => this.placeArmorInGroup(a));
  }
  private placeArmorInGroup(armor: IArmor) {
    if (armor.speedPenalty === 0) {
      this.armorGroups["Light"].push(armor);
    }
    else if(armor.speedPenalty === 10) {
      this.armorGroups["Medium"].push(armor);
    }
    else if(armor.speedPenalty === 20) {
      this.armorGroups["Heavy"].push(armor);
    }
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

  viewDetail(armor: IArmor): void {
    if(this.forSelection) {
      this.armorChosen(armor);
      return;
    }
    
    this.detailArmor = armor;
    this.appService.showSlideout();
  }
  cancelSlideout(): void {
    this.detailArmor = null;
    if(!this.forSelection) {
      this.appService.dismissSlideout();
    }
  }

  get armorGroupKeys():string[] {
    if(!this.armorGroups) {
      return null;
    }
    let groups = Object.keys(this.armorGroups);
    return groups;
  }
  armorChosen(armor:IArmor):void {
    this.armorSelected.emit(armor);
  }
}

enum ArmorSort {
  Name,
  Defense,
  Speed,
  Agility,
  Cost
}