import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ICampaignSetting, IStat, IAppliedStatMod, IStatMod, StatGroup, ICreature } from '../../../models/view-models';
import { ElixrService } from '../../services/elixr.service';
import { AppService } from '../../services/app.service';

@Component({
  selector: 'app-creature-abilities',
  templateUrl: './creature-abilities.component.html',
  styleUrls: ['./creature-abilities.component.less']
})
export class CreatureAbilitiesComponent implements OnInit {

  private _setting: ICampaignSetting;
  private statChangeOptions: IStatChangeOption[];

  @Input()
  get setting(): ICampaignSetting {
    return this._setting;
  }
  set setting(value: ICampaignSetting) {
    this._setting = value;
    if (value) {
      this.extractStats();
    }
  }
  @Input() allAppliedStatMods: IAppliedStatMod[];
  @Input() creature: ICreature;
  @Output() applyStatMod = new EventEmitter<IStatMod>();
  @Output() removeAppliedStatMods = new EventEmitter<IAppliedStatMod[]>();

  primaryAbilities: IStat[];
  racialAbilityByPrimaryStatId: { [statId: number]: IStat };
  skillsByPrimaryStatId: { [statId: number]: IStat[] };
  skillDefensesByPrimaryStatId: { [skillStatId: number]: IStat[] }
  miscByPrimaryStatId: { [statId: number]: IStat };

  constructor(private elixrService: ElixrService, private appService: AppService) {
    this.skillsByPrimaryStatId = {};
    this.miscByPrimaryStatId = {};
    this.racialAbilityByPrimaryStatId = {};
    this.skillDefensesByPrimaryStatId = {};
  }

  ngOnInit() {
  }

  getPureAbilityScore(abilityStat: IStat): number {
    return this.elixrService.sumStatMods(this.allAppliedStatMods.map(asm => asm.statMod), abilityStat.name);
  }
  getAbilityScore(abilityStat: IStat): number {
    let pureScore = this.getPureAbilityScore(abilityStat);
    let racialScoreStat = this.racialAbilityByPrimaryStatId[abilityStat.statId];
    let racialScore = this.elixrService.sumStatMods(this.allAppliedStatMods.map(asm => asm.statMod), racialScoreStat.name);
    return pureScore + racialScore;
  }
  getAbilityModifier(ability: IStat): number {
    let score = this.getAbilityScore(ability);
    return this.elixrService.calculateModifier(score);
  }
  getAbilityMisc(ability: IStat): number {
    let miscStat = this.miscByPrimaryStatId[ability.statId];
    return this.elixrService.sumStatMods(this.allAppliedStatMods.map(asm => asm.statMod), miscStat.name);
  }

  getAbilityBonus(ability: IStat): number {
    return this.getAbilityModifier(ability) + this.getAbilityMisc(ability);
  }

  getSkillMisc(skill: IStat, ability: IStat): number {
    let miscStatForSkill = this.setting.stats.filter(s => s.group === StatGroup.SkillMisc && s.parentStatId === skill.statId)[0];
    return this.sumStat(miscStatForSkill) + this.getAbilityMisc(ability);
  }

  getSkillBonus(skill: IStat, ability: IStat): number {
    return this.sumStat(skill) + this.getAbilityModifier(ability) + this.getSkillMisc(skill, ability);
  }


  sumStat(stat: IStat): number {
    if (!this.allAppliedStatMods) {
      return 0;
    }
    return this.elixrService.sumStatMods(this.allAppliedStatMods.map(asm => asm.statMod), stat.name);
  }

  statChangeIsValid(stat: IStat, mod: number): boolean {

    let newStatTotal = this.sumStat(stat) + mod;
    if (newStatTotal < 0) {
      alert("Abilities Scores and Skill Ranks cannot go below 0.")
      return false;
    }

    if (stat.group === StatGroup.Skill || stat.group === StatGroup.SkillDefense) {
      let maxSkillRanks = this.creature.level + this.setting.maxSkillRanksAboveLevel;
      if (newStatTotal > maxSkillRanks) {
        alert(`At this level, ranks cannot go to ${maxSkillRanks}`);
        return false;
      }
    }
    else { //presumably an ability score
      if (newStatTotal > this.setting.maxAbilityScore) {
        alert(`Natural Ability Scores cannot go above ${this.setting.maxAbilityScore} (though some races/templates may cause them to appear higher)`);
        return false;
      }
    }

    return true;
  }
  changeStat(stat: IStat, mod: number) {
    if (!this.statChangeIsValid(stat, mod)) {
      return;
    }
    let statMod: IStatMod = {
      modifier: mod,
      stat: stat,
      statId: stat.statId,
      reason: "Editing",
      statModId: -1
    };
    this.applyStatMod.emit(statMod);
  }

  get shouldShowRemainingStats(): boolean {
    return this.creature.isCharacter;
  }
  get remainingAbilityPoints(): number {
    let sum = 0;
    this.primaryAbilities.forEach(a => sum += this.getPureAbilityScore(a));
    return this.setting.startingAbilityPoints - sum;
  }
  get remainingSkillPoints(): number {
    let totalSkillRanksPlaced = 0;
    this.setting.stats.filter(s => s.group === StatGroup.Skill || s.group === StatGroup.SkillDefense)
      .forEach(s => totalSkillRanksPlaced += this.sumStat(s));

    return (this.setting.skillPointsEachLevel * this.creature.level) - totalSkillRanksPlaced;

  }
  cancelSlideout(): void {
    this.statChangeOptions = null;
    this.appService.dismissSlideout();
  }

  private extractStats(): void {
    this.primaryAbilities = this.setting.stats.filter(s => s.group === StatGroup.Ability)
      .sort((l, r) => l.order - r.order);

    this.primaryAbilities.forEach(s => this.cacheSkillsForPrimaryAbility(s));
    this.primaryAbilities.forEach(s => this.cacheSkillDefensesForPrimaryAbility(s));
    this.primaryAbilities.forEach(s => this.cacheMiscForPrimaryAbility(s));
    this.primaryAbilities.forEach(s => this.cacheRacialForPrimaryAbility(s));
  }
  private cacheSkillsForPrimaryAbility(abilityStat: IStat): void {
    let skillsForAbility = this.setting.stats.filter(s => s.group === StatGroup.Skill && s.parentStatId === abilityStat.statId)
      .sort((l, r) => l.name.localeCompare(r.name));
    this.skillsByPrimaryStatId[abilityStat.statId] = skillsForAbility;
  }
  private cacheSkillDefensesForPrimaryAbility(abilityStat: IStat): void {
    let skillsForAbility = this.setting.stats.filter(s => s.group === StatGroup.SkillDefense && s.parentStatId === abilityStat.statId)
      .sort((l, r) => l.name.localeCompare(r.name));
    this.skillDefensesByPrimaryStatId[abilityStat.statId] = skillsForAbility;
  }
  private cacheMiscForPrimaryAbility(abilityStat: IStat): void {
    let miscForAbility = this.setting.stats.filter(s => s.group === StatGroup.AbilityMisc && s.parentStatId === abilityStat.statId)[0];
    this.miscByPrimaryStatId[abilityStat.statId] = miscForAbility;
  }
  private cacheRacialForPrimaryAbility(abilityStat: IStat): void {
    let racialForAbility = this.setting.stats.filter(s => s.group === StatGroup.RacialAbility && s.parentStatId === abilityStat.statId)[0];
    this.racialAbilityByPrimaryStatId[abilityStat.statId] = racialForAbility;
  }
}

interface IStatChangeOption {
  value: number;
  text: string;
}