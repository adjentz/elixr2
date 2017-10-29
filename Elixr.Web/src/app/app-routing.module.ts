import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IntroComponent } from './intro/intro.component';
import { CreatureEditorComponent } from './creature-editor/creature-editor.component';
import { FeaturesComponent } from './srd/characteristics/features/features.component';
import { FlawsComponent } from './srd/characteristics/flaws/flaws.component';
import { OathsComponent } from './srd/characteristics/oaths/oaths.component';
import { RacesComponent } from './srd/races/races.component';
import { CharacteristicsComponent } from './srd/characteristics/characteristics.component';
import { SrdArmorComponent } from './srd/equipment/srd-armor/srd-armor.component';
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
import { CombatComponent } from './srd/playing-elixr/combat/combat.component';
import { ActionsComponent } from './srd/playing-elixr/combat/actions/actions.component';
import { HealingComponent } from './srd/playing-elixr/combat/healing/healing.component';
import { SocialInteractionComponent } from './srd/playing-elixr/social-interaction/social-interaction.component';
import { ExplorationComponent } from './srd/playing-elixr/exploration/exploration.component';
import { PlayerDeathComponent } from './srd/running-elixr/player-death/player-death.component';
import { RunningElixrComponent } from './srd/running-elixr/running-elixr.component';
import { CampaignsComponent } from './srd/running-elixr/campaigns/campaigns.component';
import { DungeonsComponent } from './srd/running-elixr/campaigns/dungeons/dungeons.component';
import { WorldBuildingComponent } from './srd/running-elixr/world-building/world-building.component';
import { CharacterDescriptionComponent } from './srd/character-description/character-description.component';

const routes: Routes = [
    { path: '', redirectTo: '/intro', pathMatch: 'full' },
    { path: 'intro', component: IntroComponent, data: { title: 'Intro' } },
    { path: 'creature-editor', component: CreatureEditorComponent, data: { title: 'Creature Editor' } },
    { path: 'creature-editor/:creatureId', component: CreatureEditorComponent, },
    { path: 'character-editor', component: CreatureEditorComponent, data: { isCharacter: true, title: 'Character Editor' } },
    { path: 'character-editor/:creatureId', component: CreatureEditorComponent, data: { isCharacter: true } },
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
    { path: 'srd/characteristics/features', component: FeaturesComponent, data: { title: 'Features' } },
    { path: 'srd/characteristics/flaws', component: FlawsComponent, data: { title: 'Flaws' } },
    { path: 'srd/characteristics/oaths', component: OathsComponent, data: { title: 'Oaths' } },
    { path: 'srd/skills', component: SkillsComponent, data: { title: 'Skills' } },
    { path: 'srd/equipment', component: EquipmentComponent, data: { title: 'Equipment' } },
    { path: 'srd/playing-elixr', component: PlayingElixrComponent, data: { title: 'Playing Elixr' } },
    { path: 'srd/playing-elixr/combat', component: CombatComponent, data: { title: 'Combat' } },
    { path: 'srd/playing-elixr/combat/actions', component: ActionsComponent, data: { title: 'Actions' } },
    { path: 'srd/playing-elixr/combat/healing', component: HealingComponent, data: { title: 'Healing' } },
    { path: 'srd/playing-elixr/social-interaction', component: SocialInteractionComponent, data: { title: 'Social Interaction' } },
    { path: 'srd/playing-elixr/exploration', component: ExplorationComponent, data: { title: 'Exploration' } },
    { path: 'srd/running-elixr/player-death', component: PlayerDeathComponent, data: { title: 'Player Death' } },    
    { path: 'srd/running-elixr', component: RunningElixrComponent, data: { title: 'Running Elixr' } },
    { path: 'srd/running-elixr/campaigns', component: CampaignsComponent, data: { title: 'Campaigns' } },
    { path: 'srd/running-elixr/campaigns/dungeons', component: DungeonsComponent, data: { title: 'Dungeons' } },
    { path: 'srd/running-elixr/world-building', component: WorldBuildingComponent, data: { title: 'World Building' } },
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
