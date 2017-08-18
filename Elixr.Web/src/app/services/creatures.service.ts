import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import {
  IAppliedStatMod, ICreature, IStatMod, ISelectedArmor, ISelectedWeapon, ISelectedItem,
  ISelectedSpell, ISelectedTemplate, ISelectedCharacteristic, IWealthAdjustment, ICampaignSetting
} from '../../models/view-models';

@Injectable()
export class CreaturesService {

  constructor(private apiService: ApiService) { }

  getCreatureById(id: number): Promise<ICreature> {
    return this.apiService.get(`creatures/${id}`);
  }

  saveCreature(input: ISaveCreatureInput): Promise<ICreature> {
    return this.apiService.post("creatures/save", input);
  }

  saveCreaturePortrait(portrait: File, fileName: string): Promise<any> {
    return this.apiService.postFile("creatures/save-portrait", portrait, fileName);
  }

  getCreatures(): Promise<ICreatureListingViewModel[]> {
    return this.apiService.post("creatures/search", {});
  }

  getCreatureEditorViewModel(creatureId?: number): Promise<ICreatureEditorViewModel> {
    if (creatureId) {
      return this.apiService.get(`creature-editor/view-model/${creatureId}`);
    }
    else {
      return this.apiService.get("creature-editor/view-model");
    }
  }
}

export interface ICreatureEditorViewModel {
  creature: ICreature;
  setting: ICampaignSetting;
}

export interface ISaveCreatureInput {
  creatureId: number;
  nameChangedTo: string;
  ageChangedTo: string;
  genderChangedTo: string;
  weightChangedTo: string;
  heightChangedTo: string;
  hairChangedTo: string;
  eyesChangedTo: string;
  skinChangedTo: string;
  descriptionChangedTo: string;
  levelSetTo: number;
  campaignSettingId: number;

  deletedAppliedStatModIds: number[];
  deletedSelectedArmorIds: number[];
  deletedSelectedWeaponIds: number[];
  deletedSelectedItemIds: number[];
  deletedSelectedSpellIds: number[];
  deletedSelectedTemplateIds: number[];
  deletedSelectedCharacteristicIds: number[];

  newAppliedStatMods: IAppliedStatMod[];
  newSelectedArmor: ISelectedArmor[];
  newSelectedWeapons: ISelectedWeapon[];
  newSelectedItems: ISelectedItem[];
  newSelectedSpells: ISelectedSpell[];
  newSelectedTemplates: ISelectedTemplate[];
  newSelectedCharacteristics: ISelectedCharacteristic[];

  newWealthAdjustments: IWealthAdjustment[];
}


export interface ICreatureListingViewModel {
  name: string;
  description: string;
  power: number;
  creatureId:number;
}