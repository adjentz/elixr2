import { Injectable } from '@angular/core';
import { IStatMod, IStat, StatGroup, ICharacteristic, ICampaignSetting, ICreature, ITemplate } from '../../models/view-models';

@Injectable()
export class ElixrService {

  constructor() { }

  calculateModifier(score: number): number {
    let mod = Math.floor(score) - 10;
    if (mod % 2 !== 0) {
      mod--;
    }
    mod /= 2;
    return Math.floor(mod);
  }

  convertWealthToDecimal(gold: number, silver: number, copper: number): number {
    let decimal = gold + (silver * 0.1) + (copper * 0.01);
    return Number(decimal.toFixed(2));
  }
  convertDecimalToWealth(decimal: number): { gold: number, silver: number, copper: number } {
    let gold = Math.floor(decimal);
    let remaining = decimal - gold;
    // remaining might be, say, 0.32
    let silver = Math.floor(remaining * 10);
    remaining -= silver / 10;
    let copper = Math.floor(remaining * 100);

    return {
      gold: gold,
      silver: silver,
      copper: copper
    };
  }

  getAbilityBonus(abilityName: string, mods: IStatMod[]): number {
    //TODO: I don't like how stringy all this is...
    if(abilityName.toLowerCase() === "none") {
      return 0;
    }

    let abilityScore = this.sumStatMods(mods, `${abilityName} Score`);
    let racialAbilityScore = this.sumStatMods(mods, `Racial ${abilityName} Score`);
    let totalScore = abilityScore + racialAbilityScore;
    let mod = this.calculateModifier(totalScore);
    let miscStatName = `${abilityName} Misc.`;
    let miscStats = mods.filter(sm => sm.stat.name === miscStatName);
    let misc = this.sumStatMods(miscStats, miscStatName);
    return mod + misc;
  }
  sumStatMods(mods: IStatMod[], stat: string): number {
    let sum = 0;
    mods.filter(sm => sm.stat.name.toLowerCase() === stat.toLowerCase())
      .forEach(sm => sum += sm.modifier);
    return sum;
  }

  getCreaturePower(creature: ICreature): number {
    let power = 0;
    creature.selectedCharacteristics.map(sc => sc.characteristic).forEach(c => power += this.getCharacteristicPower(c));
    creature.selectedTemplates.map(st => st.template).forEach(t => power += this.getTemplatePower(t));
    creature.mods.map(asm => asm.statMod).forEach(sm => power += this.getStatModPower(sm));
    power += creature.selectedSpells.length;
    return power;
  }
  getTemplatePower(template: ITemplate): number {
    let power = 0;
    template.mods.forEach(sm => power += this.getStatModPower(sm));
    template.appliedCharacteristics.forEach(ac => power += this.getCharacteristicPower(ac.characteristic));
    power += template.selectedSpells.length;
    return power;
  }
  getCharacteristicPower(characteristic: ICharacteristic): number {
    if (characteristic.specifiedPowerAdjustment) {
      return characteristic.specifiedPowerAdjustment;
    }
    let power = 0;
    characteristic.mods.forEach(sm => power += this.getStatModPower(sm));
    return power;
  }
  getStatModPower(statMod: IStatMod): number {
    return statMod.stat.powerRating * Math.ceil(statMod.modifier / statMod.stat.ratio);
  }

  getMaxValue(stat: IStat, creature: ICreature): number {
    if (!stat.maxValueFormula) {
      return stat.maxValue;
    }

    let tokens: { [key: string]: string } = {};
    tokens["{level}"] = creature.level.toString();


    let formula = stat.maxValueFormula;
    while (formula.includes(" ")) {
      formula = formula.replace(" ", "");
    }
    Object.keys(tokens).forEach(token => formula = formula.replace(token, tokens[token]));
    if (!/^[0-9\+\-\*\/]*$/.test(formula)) {
      throw `Invalid formula (${formula})`;
    }
    return eval(formula);
  }
}
interface IFormulaPart {
  num: number;
  op: Operator;
}
enum Operator {
  Plus,
  Minus,
  Multiply,
  Divide
}
