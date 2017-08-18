import { Component, OnInit, Input } from '@angular/core';
import { ElixrService } from '../../services/elixr.service';
import { IStatMod, IAppliedStatMod } from '../../../models/view-models';

@Component({
  selector: 'app-creature-energy',
  templateUrl: './creature-energy.component.html',
  styleUrls: ['./creature-energy.component.less', '../creature-sources.less']
})
export class CreatureEnergyComponent implements OnInit {

  @Input() allAppliedStatMods: IAppliedStatMod[];

  constructor(private statModsService: ElixrService) { }

  ngOnInit() {
  }

  get energySources(): IStatMod[] {
    return this.allAppliedStatMods.filter(asm => asm.statMod.stat.name === "Energy")
                                  .sort((lhs, rhs) => lhs.appliedAtUnixMS - rhs.appliedAtUnixMS)
                                  .map(asm => asm.statMod);
  }

  get totalEnergy(): number {
    return this.statModsService.sumStatMods(this.allAppliedStatMods.map(asm => asm.statMod), "Energy");
  }
}
