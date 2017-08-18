import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AppService } from '../../services/app.service';
import { ElixrService } from '../../services/elixr.service';
import { IAppliedStatMod, IStatMod, ICampaignSetting, IWealthAdjustment } from '../../../models/view-models';

@Component({
  selector: 'app-creature-wealth',
  templateUrl: './creature-wealth.component.html',
  styleUrls: ['../creature-sources.less']
})
export class CreatureWealthComponent implements OnInit {

  newGold = 0;
  newSilver = 0;
  newCopper = 0;
  increasingWealth = true;
  editingWealth = false;
  memo = "";

  @Output() wealthChanged = new EventEmitter<IWealthAdjustment>();
  @Input() wealthAdjustments: IWealthAdjustment[];

  constructor(public appService: AppService, private elixrService: ElixrService) {

  }

  ngOnInit() {
  }
  showSlideout(): void {
    this.appService.showSlideout();
    this.editingWealth = true;
  }

  private get wealth(): number {
    if(!this.wealthAdjustments) {
      return 0;
    }
    let num = 0;
    this.wealthAdjustments.forEach(wa => num += wa.amount);
    return num;
  }
  get sources(): IWealthAdjustment[] {
    if(!this.wealthAdjustments) {
      return null;
    }
    return this.wealthAdjustments.sort((lhs, rhs) => lhs.adjustedAtMS - rhs.adjustedAtMS);
  }
  get gold(): number {
    return this.elixrService.convertDecimalToWealth(this.wealth).gold;
  }
  get silver(): number {
    return this.elixrService.convertDecimalToWealth(this.wealth).silver;
  }
  get copper(): number {
    return this.elixrService.convertDecimalToWealth(this.wealth).copper;
  }

  editWealth(): void {
    this.newGold = Math.abs(this.newGold);
    this.newSilver = Math.abs(this.newSilver);
    this.newCopper = Math.abs(this.newCopper);

    let reason = this.memo;
    if (!reason) {
      reason = this.increasingWealth ? "Increasing" : "Decreasing";
      reason += " Wealth";
    }

    let wealthAdjustment: IWealthAdjustment = {
      adjustedAtMS: Date.now(),
      amount: this.newGold + (this.newSilver / 10.0) + (this.newCopper / 100.0),
      reason: reason,
      wealthAdjustmentId: -1 //doesn't need a tracking code as wealth adjustments never get removed.
    };
    if (!this.increasingWealth) {
      wealthAdjustment.amount *= -1;
    }
    this.wealthChanged.emit(wealthAdjustment);

    this.cancelSlideout();
  }

  cancelSlideout(): void {
    this.newCopper = 0;
    this.newSilver = 0;
    this.newGold = 0;
    this.increasingWealth = true;
    this.editingWealth = false;
    this.memo = "";
    this.appService.dismissSlideout();
  }

  getSourceClass(source: IWealthAdjustment): string {
    if (source.amount < 0) {
      return "fa fa-minus";
    }
    return "fa fa-plus";
  }
}
