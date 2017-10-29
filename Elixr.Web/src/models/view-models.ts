
export enum StatGroup {
    Character = 0,
    Ability = 10,
    RacialAbility = 11,
    AbilityMisc = 12,
    Skill = 20,
    SkillDefense = 21,
    SkillMisc = 22
}

export interface ICampaignSetting {
    campaignSettingId: number;
    name: string;
    stats: IStat[];
    baseDefense: number;
    maxAbilityScore: number;
    abilityPointsEachLevel: number;
    startingAbilityPoints: number;
    skillPointsEachLevel: number;
    startingWealth: number;
    initialMods: IStatMod[];
    modsEachLevel: IStatMod[];
    characteristicPointsEachLevel: number;
    maxSkillRanksAboveLevel: number;
}
export interface IStatMod {
    statModId: number;
    reason: string;
    statId: number;
    stat: IStat;
    modifier: number;
}
export interface IStat {
    statId: number;
    name: string;
    displayName: string;
    group: StatGroup;
    maxValue: number;
    maxValueFormula: string;
    powerRating: number;
    nonModdable: boolean;
    ratio: number;
    order: number;
    parentStatId: number;
    description: string;
}

export interface ICreature {
    creatureId: number;
    level: number;
    name: string;
    age: string;
    description: string;
    gender: string;
    eyes: string;
    hair: string;
    height: string;
    weight: string;
    skin: string;
    isCharacter: boolean;
    mods: IAppliedStatMod[];
    selectedTemplates: ISelectedTemplate[];
    selectedCharacteristics: ISelectedCharacteristic[];
    selectedArmor: ISelectedArmor[];
    selectedWeapons: ISelectedWeapon[];
    selectedItems: ISelectedItem[];
    selectedSpells: ISelectedSpell[];
    wealthAdjustments: IWealthAdjustment[];
}
export interface ISelectedArmor {
    selectedArmorId: number;
    notes: string;
    armor: IArmor;
    selectedAtMS: number;
}
export interface IAppliedStatMod {
    appliedStatModId: number;
    statMod: IStatMod;
    appliedAtLevel: number;
    appliedAtUnixMS: number;
}

export enum CharacteristicType {
    Other = 0,
    Flaw = 1,
    Oath = 2,
    Feature = 3
}
export interface ICharacteristic {
    id: number;
    name: string;
    type: CharacteristicType;
    mods: IStatMod[];
    specifiedPowerAdjustment?: number;
}

export interface ISelectedCharacteristic {
    selectedCharacteristicId: number;
    takenAtMS: number;
    takenAtLevel: number;
    characteristic: ICharacteristic;
    isTemplateCharacteristic: boolean;
    notes: string;
}

export interface ITemplate {
    templateId: number;
    name: string;
    description: string;
    mods: IStatMod[];
    appliedCharacteristics: ISelectedCharacteristic[];
    selectedSpells: ISelectedSpell[];
    isRace: boolean;
}

export interface IEquipment {
    weightInPounds: number;
    name: string;
    description: string;
    goldCost: number;
    silverCost: number;
    copperCost: number;
}

export interface IItem extends IEquipment {

}

export interface IArmor extends IEquipment {
    defenseBonus: number;
    armorId: number;
    speedPenalty: number;
    agilityPenalty: number;
}
export enum WeaponUseAbility {
    Strength = 0,
    Agility = 1,
    Focus = 2,
    Charm = 3,
    None = 4
}

export interface IWeaponCharacteristic {
    weaponCharacteristicId: number;
    name: string;
    description: string;
    attackBonusMod: number;
    damageBonusMod: number;
    specifiedPowerAdjustment?: number;
    extraDamage: string;
}
export interface ISelectedWeaponCharacteristic {
    selectedWeaponCharacteristicId: number;
    takenAtMS: number;
    takenAtLevel: number;
    characteristic: IWeaponCharacteristic;
    notes: string;
}
export interface IWeapon extends IEquipment {
    attackAbility: WeaponUseAbility;
    damageAbility: WeaponUseAbility;
    weaponId: number;
    isTwoHanded: boolean;
    canSlash: boolean;
    canPierce: boolean;
    canBludgeon: boolean;
    hasReach: boolean;
    damage: string;
    range: number;
}

export interface ISelectedWeapon {
    weapon: IWeapon;
    selectedAtMS: number;
    notes: string;
    selectedWeaponId: number;
    appliedCharacteristics: ISelectedWeaponCharacteristic[]
}

export interface ISelectedItem {
    item: IItem;
    selectedAtMS: number;
    notes: string;
    selectedItemId: number;
}

export interface ISpell {
    spellId: number;
    name: string;
    description: string;
    energyRequired: string;
    isConcentration: boolean;
    doesDamage: boolean;
}
export interface ISelectedSpell {
    selectedSpellId: number;
    spell: ISpell;
    selectedAtMS: number;
    selectedAtLevel: number;
    notes: string;
}

export interface ISelectedTemplate {
    selectedTemplateId: number;
    templateId: number;
    template: ITemplate;
    selectedAtMS: number;
    notes: string;
}

export interface IWealthAdjustment {
    amount: number;
    reason: string;
    adjustedAtMS: number;
    wealthAdjustmentId: number;
}

export interface ISkill extends IStat {
    opposedBy: string,
    speedCost: string,
    hasDefense: boolean
}