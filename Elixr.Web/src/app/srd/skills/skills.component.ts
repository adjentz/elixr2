import { Component, OnInit } from '@angular/core';
import { StatsService } from '../../services/stats.service';
import { IStat, StatGroup, ISkill } from '../../../models/view-models';

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.css']
})
export class SkillsComponent implements OnInit {

  skillsByAbilityId: { [abilityStatId: number]: ISkill[] };
  abilityStats: IStat[];
  constructor(private statsService: StatsService) {
    this.skillsByAbilityId = {};
  }

  async ngOnInit() {
    let skillsPromise = this.statsService.getSkills();
    let abilityStatsPromise = this.statsService.getStatsInGroup(StatGroup.Ability);
    let results = await Promise.all([skillsPromise, abilityStatsPromise]);
    let skills = results[0];
    this.abilityStats = results[1];

    this.abilityStats = this.abilityStats.sort((lhs, rhs) => lhs.order - rhs.order);
    this.abilityStats.forEach(a => this.skillsByAbilityId[a.statId] = skills.filter(s => s.parentStatId === a.statId).sort((lhs, rhs) => lhs.order - rhs.order));
  }

}
