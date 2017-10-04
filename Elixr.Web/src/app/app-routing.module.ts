import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IntroComponent } from './intro/intro.component';
import { CreatureEditorComponent } from './creature-editor/creature-editor.component';
import { FeaturesComponent } from './srd/features/features.component';
import { RacesComponent } from './srd/races/races.component';
import { CharacteristicsComponent } from './srd/characteristics/characteristics.component';
import { SrdArmorComponent } from './srd/equipment/armor/srd-armor.component';
import { SrdWeaponsComponent } from './srd/equipment/srd-weapons/srd-weapons.component';
import { SrdItemsComponent } from './srd/equipment/srd-items/srd-items.component';
import { MagicComponent } from './srd/magic/magic.component';
import { CreaturesComponent } from './srd/creatures/creatures.component';
import { CreatingACharacterComponent } from './srd/creating-a-character/creating-a-character.component';
import { BaseStatsComponent } from './srd/base-stats/base-stats.component';
import { AbilitiesComponent } from './srd/abilities/abilities.component';
import { EquipmentComponent } from './srd/equipment/equipment.component';
import { SkillsComponent } from './srd/skills/skills.component';
import { PlayingElixrComponent } from './srd/playing-elixr/playing-elixr.component';
import { RunningElixrComponent } from './srd/running-elixr/running-elixr.component';
import { CharacterDescriptionComponent } from './srd/character-description/character-description.component';

const routes: Routes = [
    { path: '', redirectTo: '/intro', pathMatch: 'full' },
    { path: 'intro', component: IntroComponent, data: { title: 'Intro' } },
    { path: 'creature-editor', component: CreatureEditorComponent, data: { title: 'Creature Editor' } },
    { path: 'creature-editor/:creatureId', component: CreatureEditorComponent, },
    { path: 'character-editor', component: CreatureEditorComponent, data: { isCharacter: true, title: 'Character Editor' } },
    { path: 'character-editor/:creatureId', component: CreatureEditorComponent, data: { isCharacter: true } },
    { path: 'srd/features', component: FeaturesComponent, data: { title: 'Features' } },
    { path: 'srd/races', component: RacesComponent, data: { title: 'Races' } },
    { path: 'srd/equipment/armor', component: SrdArmorComponent, data: { title: 'Armor' } },
    { path: 'srd/equipment/weapons', component: SrdWeaponsComponent, data: { title: 'Weapons' } },
    { path: 'srd/equipment/items', component: SrdItemsComponent, data: { title: 'Items' } },
    { path: 'srd/magic', component: MagicComponent, data: { title: 'Magic' } },
    { path: 'srd/creatures', component: CreaturesComponent, data: { title: 'Creatures' } },
    { path: 'srd/creating-a-character', component: CreatingACharacterComponent, data: { title: 'Creating a Character' } },
    { path: 'srd/base-stats', component: BaseStatsComponent, data: { title: 'Base Stats' } },
    { path: 'srd/character-description', component: CharacterDescriptionComponent, data: { title: 'Character Description' } },
    { path: 'srd/abilities', component: AbilitiesComponent, data: { title: 'Abilities' } },
    { path: 'srd/characteristics', component: CharacteristicsComponent, data: { title: 'Characteristics' } },
    { path: 'srd/skills', component: SkillsComponent, data: { title: 'Skills' } },
    { path: 'srd/equipment', component: EquipmentComponent, data: { title: 'Equipment' } },
    { path: 'srd/playing-elixr', component: PlayingElixrComponent, data: { title: 'Playing Elixr' } },
    { path: 'srd/running-elixr', component: RunningElixrComponent, data: { title: 'Running Elixr' } },
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
