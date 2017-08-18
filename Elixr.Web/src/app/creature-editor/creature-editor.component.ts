import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CreaturesService, ISaveCreatureInput } from '../services/creatures.service';
import { ElixrService } from '../services/elixr.service';
import {
  StatGroup, ICreature, IStat, IStatMod, IAppliedStatMod, ISelectedCharacteristic,
  ICampaignSetting, ICharacteristic, CharacteristicType, ITemplate,
  IArmor, ISelectedArmor, IWeapon, ISelectedWeapon, ISelectedItem, IItem, ISelectedSpell, ISpell,
  ISelectedTemplate, IWealthAdjustment
} from '../../models/view-models';
import { IChosenArmor } from './creature-defense/creature-defense.component';
import { IChosenWeapon } from './creature-attacks/creature-attacks.component';
import { IChosenItem } from './creature-equipment/creature-equipment.component';

@Component({
  selector: 'app-creature-editor',
  templateUrl: './creature-editor.component.html',
  styleUrls: ['./creature-editor.component.less']
})
export class CreatureEditorComponent implements OnInit {

  loading = true;
  campaignSetting: ICampaignSetting;
  newCreature = false;
  isCharacter = false;
  creature: ICreature;
  newPortrait: File; //undefined if not changed

  removedAppliedStatModIds: number[];
  removedSelectedArmorIds: number[];
  removedSelectedWeaponIds: number[];
  removedSelectedItemIds: number[];
  removedSelectedSpellIds: number[];
  removedSelectedTemplateIds: number[];
  removedSelectedCharacteristicIds: number[];

  private _trackingCode = 0;
  private static groupdTrackingCode = 10000;

  constructor(
    private route: ActivatedRoute,
    private elixrService: ElixrService,
    private creaturesService: CreaturesService) {
    this.removedAppliedStatModIds = [];
    this.removedSelectedArmorIds = [];
    this.removedSelectedWeaponIds = [];
    this.removedSelectedItemIds = [];
    this.removedSelectedSpellIds = [];
    this.removedSelectedTemplateIds = [];
    this.removedSelectedCharacteristicIds = [];
  }

  ngOnInit() {

    this.isCharacter = this.route.snapshot.data["isCharacter"];

    this.route.params.subscribe(p => {
      this.getViewModel(p["creatureId"]);
    });
  }

  async getViewModel(creatureId: any) {
    this.loading = true;

    let vm = await this.creaturesService.getCreatureEditorViewModel(creatureId);
    this.campaignSetting = vm.setting;
    this.creature = vm.creature;
    this.creature.isCharacter = this.isCharacter;
    this.initCharacter();
    this.loading = false;
  }

  initCharacter(): void {
    if (!this.creature.isCharacter || this.creature.level > 0) {
      return;
    }
    if (this.campaignSetting.startingWealth > 0) {
      this.creature.wealthAdjustments.push({
        adjustedAtMS: Date.now(),
        amount: this.campaignSetting.startingWealth,
        reason: "Starting Wealth",
        wealthAdjustmentId: this.nextTrackingCode
      });
    }

    this.creature.level = 1;
    this.campaignSetting.initialMods.forEach(sm => this.applyStatMod(sm));
  }

  findStatById(statId: number): IStat {
    return this.campaignSetting.stats.find(s => s.statId === statId);
  }

  levelUp(): void {
    this.creature.level++;
    this.campaignSetting.modsEachLevel.forEach(sm => this.applyStatMod(sm));
  }
  levelDown(): void {
    if (this.creature.level === 1) {
      return;
    }
    //equipment & templates stay, but Mods/Characteristics/Spells are removed.
    let appliedModsAtLevel = this.creature.mods.filter(sm => !this.statIsWealthBased(sm.statMod.stat) && sm.appliedAtLevel >= this.creature.level);
    appliedModsAtLevel.forEach(asm => this.removeAppliedStat(asm));

    let selectedCharacteristicsAtLevel = this.creature.selectedCharacteristics.filter(sc => sc.takenAtLevel >= this.creature.level);
    selectedCharacteristicsAtLevel.forEach(sc => this.characteristicRemoved(sc));

    let selectedSpellsAtLevel = this.creature.selectedSpells.filter(ss => ss.selectedAtLevel >= this.creature.level);
    selectedSpellsAtLevel.forEach(ss => this.spellRemoved(ss));

    this.creature.level--;
  }

  private statIsWealthBased(stat: IStat): boolean {
    let statName = stat.name.toLowerCase();
    return statName === "copper" || statName === "silver" || statName === "gold";
  }

  removeAppliedStatMods(appliedStatMods: IAppliedStatMod[]): void {
    appliedStatMods.forEach(asm => this.removeAppliedStat(asm));
  }

  removeAppliedStat(appliedStatMod: IAppliedStatMod): void {
    let index = this.creature.mods.findIndex(asm => asm.appliedStatModId === appliedStatMod.appliedStatModId);
    if (index > -1) {
      this.creature.mods.splice(index, 1);

      if (appliedStatMod.appliedStatModId > 0) {
        this.removedAppliedStatModIds.push(appliedStatMod.appliedStatModId);
      }
    }
  }
  save(): void {
    console.log(this.creature);
    // let newMods = this.creature.mods.filter(asm => asm.appliedStatModId < 0);
    // let newTemplates = this.creature.selectedTemplates.filter(st => st.selectedTemplateId < 0);
    // let newCharacteristics = this.creature.selectedCharacteristics.filter(sc => sc.selectedCharacteristicId < 0);
    // let newArmor = this.creature.selectedArmor.filter(sa => sa.selectedArmorId < 0);
    // let newWeapons = this.creature.selectedWeapons.filter(sw => sw.selectedWeaponId < 0);
    // let newItems = this.creature.selectedItems.filter(si => si.selectedItemId < 0);
    // let newSpells = this.creature.selectedSpells.filter(ss => ss.selectedSpellId < 0);
    // let newWealthAdjustments = this.creature.wealthAdjustments.filter(wa => wa.wealthAdjustmentId < 0);

    // let input: ISaveCreatureInput = {
    //   ageChangedTo: this.creature.age,
    //   descriptionChangedTo: this.creature.description,
    //   eyesChangedTo: this.creature.eyes,
    //   genderChangedTo: this.creature.gender,
    //   hairChangedTo: this.creature.hair,
    //   heightChangedTo: this.creature.height,
    //   nameChangedTo: this.creature.name,
    //   skinChangedTo: this.creature.skin,
    //   weightChangedTo: this.creature.weight,

    //   newAppliedStatMods: newMods,
    //   newSelectedArmor: newArmor,
    //   newSelectedCharacteristics: newCharacteristics,
    //   newSelectedItems: newItems,
    //   newSelectedSpells: newSpells,
    //   newSelectedTemplates: newTemplates,
    //   newSelectedWeapons: newWeapons,

    //   deletedAppliedStatModIds: this.removedAppliedStatModIds,
    //   deletedSelectedArmorIds: this.removedSelectedArmorIds,
    //   deletedSelectedCharacteristicIds: this.removedSelectedCharacteristicIds,
    //   deletedSelectedItemIds: this.removedSelectedItemIds,
    //   deletedSelectedSpellIds: this.removedSelectedSpellIds,
    //   deletedSelectedTemplateIds: this.removedSelectedTemplateIds,
    //   deletedSelectedWeaponIds: this.removedSelectedWeaponIds,

    //   creatureId: this.creature.creatureId,
    //   levelSetTo: this.creature.level,
    //   campaignSettingId: this.campaignSetting.campaignSettingId,

    //   newWealthAdjustments: newWealthAdjustments,
    // };

    // this.creaturesService.saveCreature(input);

  }

  takeCharacteristic(characteristic: ICharacteristic): void {

    let selectedCharacteristic: ISelectedCharacteristic = {
      characteristic: characteristic,
      isTemplateCharacteristic: false,
      notes: "",
      selectedCharacteristicId: this.nextTrackingCode,
      takenAtLevel: this.creature.level,
      takenAtMS: Date.now()
    };

    this.creature.selectedCharacteristics = [selectedCharacteristic].concat(this.creature.selectedCharacteristics);
  }

  characteristicRemoved(selectedCharacteristic: ISelectedCharacteristic): void {
    let selectedCharacteristiceIndex = this.creature.selectedCharacteristics.findIndex(tc => tc.selectedCharacteristicId === selectedCharacteristic.selectedCharacteristicId);
    if (selectedCharacteristiceIndex < 0) {
      return;
    }
    this.creature.selectedCharacteristics.splice(selectedCharacteristiceIndex, 1);
    if (selectedCharacteristic.selectedCharacteristicId > 0) {
      this.removedSelectedCharacteristicIds.push(selectedCharacteristic.selectedCharacteristicId);
    }
  }

  portraitChanged(file: File) {
    this.newPortrait = file;
  }

  templateSelected(template: ITemplate): void {

    this.creature.selectedTemplates.push({
      notes: "",
      selectedAtMS: Date.now(),
      selectedTemplateId: this.nextTrackingCode,
      template: template,
      templateId: template.templateId
    });
  }

  templateRemoved(selectedTemplate: ISelectedTemplate): void {
    let templateIndex = this.creature.selectedTemplates.findIndex(st => st.selectedTemplateId === selectedTemplate.selectedTemplateId);
    if (templateIndex === -1) {
      return;
    }
    this.creature.selectedTemplates.splice(templateIndex, 1);
    this.removedSelectedTemplateIds.push(selectedTemplate.selectedTemplateId);
  }

  private applyCost(gold: number, silver: number, copper: number, reason: string, trackingId: number): void {
    gold = Math.abs(gold);
    silver = Math.abs(silver);
    copper = Math.abs(copper);

    let modsByStatName: { [statName: string]: number } = {};
    modsByStatName["Gold"] = gold;
    modsByStatName["Silver"] = silver;
    modsByStatName["Copper"] = copper;

    let adjustment = gold + (silver / 10.0) + (copper / 100.0);
    adjustment *= -1;
    let wealthAdjustment: IWealthAdjustment = {
      adjustedAtMS: Date.now(),
      amount: adjustment,
      reason: reason,
      wealthAdjustmentId: this.nextTrackingCode
    };
    this.creature.wealthAdjustments.push(wealthAdjustment);
  }
  armorSelected(chosenArmor: IChosenArmor): void {

    let selectedArmor: ISelectedArmor = {
      armor: chosenArmor.armor,
      notes: "",
      selectedArmorId: this.nextTrackingCode,
      selectedAtMS: Date.now()
    };
    this.creature.selectedArmor.push(selectedArmor);

    if (chosenArmor.applyCost) {
      let armor = selectedArmor.armor;
      let reason = `Purchased ${armor.name}`;
      this.applyCost(armor.goldCost, armor.silverCost, armor.copperCost, reason, selectedArmor.selectedArmorId);
    }
    let stat = this.campaignSetting.stats.filter(s => s.name === "Agility Score")[0];
    let statMod: IStatMod = {
      modifier: -selectedArmor.armor.agilityPenalty,
      reason: `Wearing ${selectedArmor.armor.name}`,
      stat: stat,
      statId: stat.statId,
      statModId: this.nextTrackingCode
    };
    this.applyStatMod(statMod);

    stat = this.campaignSetting.stats.filter(s => s.name === "Speed")[0];
    statMod = {
      modifier: -selectedArmor.armor.speedPenalty,
      reason: `Wearing ${selectedArmor.armor.name}`,
      stat: stat,
      statId: stat.statId,
      statModId: this.nextTrackingCode
    };
    this.applyStatMod(statMod);
  }

  applyStatMod(statMod: IStatMod): void {
    this.creature.mods.push({
      appliedAtLevel: this.creature.level,
      appliedAtUnixMS: Date.now(),
      appliedStatModId: this.nextTrackingCode,
      statMod: statMod
    });
  }

  armorRemoved(selectedArmor: ISelectedArmor): void {

    let index = this.creature.selectedArmor.findIndex(sa => sa.selectedArmorId === selectedArmor.selectedArmorId);
    if (index === -1) {
      return;
    }
    this.creature.selectedArmor.splice(index, 1);
    if (selectedArmor.selectedArmorId > 0) {
      this.removedSelectedArmorIds.push(selectedArmor.selectedArmorId);
    }

    let stat = this.campaignSetting.stats.filter(s => s.name === "Agility Score")[0];
    let statMod: IStatMod = {
      modifier: selectedArmor.armor.agilityPenalty,
      reason: `Removed ${selectedArmor.armor.name}`,
      stat: stat,
      statId: stat.statId,
      statModId: this.nextTrackingCode
    };
    this.applyStatMod(statMod);

    stat = this.campaignSetting.stats.filter(s => s.name === "Speed")[0];
    statMod = {
      modifier: selectedArmor.armor.speedPenalty,
      reason: `Removed ${selectedArmor.armor.name}`,
      stat: stat,
      statId: stat.statId,
      statModId: this.nextTrackingCode
    };
    this.applyStatMod(statMod);
  }

  weaponSelected(chosenWeapon: IChosenWeapon): void {
    let selectedWeapon: ISelectedWeapon = {
      weapon: chosenWeapon.weapon,
      notes: "",
      selectedWeaponId: this.nextTrackingCode,
      selectedAtMS: Date.now(),
      appliedCharacteristics: []
    };
    this.creature.selectedWeapons.push(selectedWeapon);

    if (chosenWeapon.applyCost) {
      let weapon = selectedWeapon.weapon;
      let reason = `Purchased ${weapon.name}`;
      this.applyCost(weapon.goldCost, weapon.silverCost, weapon.copperCost, reason, selectedWeapon.selectedWeaponId);
    }
  }

  weaponRemoved(selectedWeapon: ISelectedWeapon): void {
    let index = this.creature.selectedWeapons.findIndex(sw => sw.selectedWeaponId === selectedWeapon.selectedWeaponId);
    if (index === -1) {
      return;
    }
    this.creature.selectedWeapons.splice(index, 1);
    if (selectedWeapon.selectedWeaponId > 0) {
      this.removedSelectedWeaponIds.push(selectedWeapon.selectedWeaponId);
    }
  }

  itemSelected(chosenItem: IChosenItem): void {
    let selectedItem: ISelectedItem = {
      item: chosenItem.item,
      notes: "",
      selectedItemId: this.nextTrackingCode,
      selectedAtMS: Date.now()
    };
    this.creature.selectedItems.push(selectedItem);

    if (chosenItem.applyCost) {
      let item = selectedItem.item;
      let reason = `Purchased ${item.name}`;
      this.applyCost(item.goldCost, item.silverCost, item.copperCost, reason, selectedItem.selectedItemId);
    }
  }

  itemRemoved(selectedItem: ISelectedItem): void {
    let index = this.creature.selectedItems.findIndex(sw => sw.selectedItemId === selectedItem.selectedItemId);
    if (index === -1) {
      return;
    }
    this.creature.selectedItems.splice(index, 1);
    if (selectedItem.selectedItemId > 0) {
      this.removedSelectedItemIds.unshift(selectedItem.selectedItemId);
    }
  }

  spellSelected(spell: ISpell): void {
    let selectedSpell: ISelectedSpell = {
      spell: spell,
      notes: "",
      selectedSpellId: this.nextTrackingCode,
      selectedAtMS: Date.now(),
      selectedAtLevel: this.creature.level
    };
    this.creature.selectedSpells.push(selectedSpell);
  }
  spellRemoved(selectedSpell: ISelectedSpell): void {
    let index = this.creature.selectedSpells.findIndex(sp => sp.selectedSpellId === selectedSpell.selectedSpellId);
    if (index === -1) {
      return;
    }
    this.creature.selectedSpells.splice(index, 1);
    this.removedSelectedSpellIds.push(selectedSpell.selectedSpellId);
  }

  wealthChanged(wealthAdjustment: IWealthAdjustment): void {
    this.creature.wealthAdjustments.push(wealthAdjustment);
  }

  private get nextTrackingCode(): number {
    return --this._trackingCode;
  }

  private selectedCharacteristicModToAppliedMod(selectedCharacteristic: ISelectedCharacteristic, statMod: IStatMod): IAppliedStatMod {
    return {
      appliedAtLevel: selectedCharacteristic.takenAtLevel,
      appliedAtUnixMS: selectedCharacteristic.takenAtMS,
      appliedStatModId: selectedCharacteristic.selectedCharacteristicId,
      statMod: statMod
    };
  }

  private selectedTemplateModToAppliedMod(selectedTemplate: ISelectedTemplate, statMod: IStatMod): IAppliedStatMod {
    return {
      appliedAtLevel: 0,
      appliedAtUnixMS: selectedTemplate.selectedAtMS,
      appliedStatModId: selectedTemplate.selectedTemplateId,
      statMod: statMod
    };
  }

  get allAppliedStatMods(): IAppliedStatMod[] {
    if (!this.creature || !this.creature.mods) {
      return [];
    }

    let result = [...this.creature.mods];
    for (let selectedCharacteristic of this.creature.selectedCharacteristics) {
      for (let mod of selectedCharacteristic.characteristic.mods) {
        let appliedMod = this.selectedCharacteristicModToAppliedMod(selectedCharacteristic, mod);
        result.push(appliedMod);
      }
    }

    for (let selectedTemplate of this.creature.selectedTemplates) {

      for (let mod of selectedTemplate.template.mods) {

        let templateAppliedMod = this.selectedTemplateModToAppliedMod(selectedTemplate, mod);
        result.push(templateAppliedMod);
      }
      for (let selectedCharacteristic of selectedTemplate.template.appliedCharacteristics) {
        for (let mod of selectedCharacteristic.characteristic.mods) {
          let appliedMod = this.selectedCharacteristicModToAppliedMod(selectedCharacteristic, mod);
          result.push(appliedMod);
        }
      }
    }

    return result;
  }
}
