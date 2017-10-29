import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { IStat, StatGroup, ISkill } from '../../models/view-models';
@Injectable()
export class StatsService {

  constructor(private apiService: ApiService) { }

  getSkills(): Promise<ISkill[]> {
    return this.apiService.get('skills');
  }

  getStatsInGroup(group: StatGroup): Promise<IStat[]> {
    return this.apiService.get(`stats/${group}`);
  }
}
