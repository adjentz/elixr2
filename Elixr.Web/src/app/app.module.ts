import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';


import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

//SRD
import { IntroComponent } from './intro/intro.component';

//Editor
import { CreatureEditorComponent } from './creature-editor/creature-editor.component';
import { ApiService } from './services/api.service';
import { ArmorService } from './services/armor.service';
import { WeaponService } from './services/weapons.service';
import { ItemService } from './services/items.service';
import { SpellsService } from './services/spells.service';
import { CreaturesService } from './services/creatures.service';
import { CharacteristicService } from './services/characteristics.service';
import { TemplatesService } from './services/templates.service';
import { ElixrService } from './services/elixr.service';
import { AppService } from './services/app.service';
import { MarkdownService } from './services/markdown.service';
import { CreatureDescriptionComponent } from './creature-editor/creature-description/creature-description.component';
import { CreatureAbilitiesComponent } from './creature-editor/creature-abilities/creature-abilities.component';
import { CreatureEnergyComponent } from './creature-editor/creature-energy/creature-energy.component';
import { CreatureSpellSlotsComponent } from './creature-editor/creature-spell-slots/creature-spell-slots.component';
import { CreatureDefenseComponent } from './creature-editor/creature-defense/creature-defense.component';
import { CreatureItemsComponent } from './creature-editor/creature-items/creature-items.component';
import { CreatureSpellsComponent } from './creature-editor/creature-spells/creature-spells.component';
import { CreatureCharacteristicsComponent } from './creature-editor/creature-characteristics/creature-characteristics.component';
import { CreatureAttacksComponent } from './creature-editor/creature-attacks/creature-attacks.component';
import { MarkdownEditorComponent } from './components/markdown-editor/markdown-editor.component';
import { CreatureWealthComponent } from './creature-editor/creature-wealth/creature-wealth.component';
import { CreatureEquipmentComponent } from './creature-editor/creature-equipment/creature-equipment.component';
import { CharacteristicsComponent } from './characteristics/characteristics.component';
import { CharacteristicComponent } from './characteristics/characteristic/characteristic.component';
import { CharacteristicsComponent as SrdCharacteristics } from './srd/characteristics/characteristics.component';
import { RacesComponent } from './srd/races/races.component';
import { TemplatesComponent } from './templates/templates.component';
import { TemplateComponent } from './templates/template/template.component';
import { SelectedCharacteristicDetailComponent } from './components/selected-characteristic-detail/selected-characteristic-detail.component';
import { SrdArmorComponent } from './srd/equipment/srd-armor/srd-armor.component';
import { ArmorDetailComponent } from './armor/armor-detail/armor-detail.component';
import { ArmorComponent } from './armor/armor.component';
import { WeaponsComponent } from './weapons/weapons.component';
import { WeaponDetailComponent } from './weapons/weapon-detail/weapon-detail.component';
import { ItemsComponent } from './items/items.component';
import { ItemDetailComponent } from './items/item-detail/item-detail.component';
import { SpellsComponent } from './spells/spells.component';
import { SpellDetailComponent } from './spells/spell-detail/spell-detail.component';
import { SrdWeaponsComponent } from './srd/equipment/srd-weapons/srd-weapons.component';
import { SrdItemsComponent } from './srd/equipment/srd-items/srd-items.component';
import { MagicComponent } from './srd/magic/magic.component';
import { CreaturesComponent } from './srd/creatures/creatures.component';
import { CreatingACharacterComponent } from './srd/creating-a-character/creating-a-character.component';
import { BaseStatsComponent } from './srd/base-stats/base-stats.component';
import { CharacterDescriptionComponent } from './srd/character-description/character-description.component';
import { AbilitiesComponent } from './srd/abilities/abilities.component';
import { SkillsComponent } from './srd/skills/skills.component';
import { PlayingElixrComponent } from './srd/playing-elixr/playing-elixr.component';
import { RunningElixrComponent } from './srd/running-elixr/running-elixr.component';
import { EquipmentComponent } from './srd/equipment/equipment.component';
import { FeaturesComponent } from './srd/characteristics/features/features.component';
import { FlawsComponent } from './srd/characteristics/flaws/flaws.component';
import { OathsComponent } from './srd/characteristics/oaths/oaths.component';
import { CombatComponent } from './srd/playing-elixr/combat/combat.component';
import { SocialInteractionComponent } from './srd/playing-elixr/social-interaction/social-interaction.component';
import { ExplorationComponent } from './srd/playing-elixr/exploration/exploration.component';
import { ActionsComponent } from './srd/playing-elixr/combat/actions/actions.component';
import { HealingComponent } from './srd/playing-elixr/combat/healing/healing.component';
import { CampaignsComponent } from './srd/running-elixr/campaigns/campaigns.component';
import { DungeonsComponent } from './srd/running-elixr/campaigns/dungeons/dungeons.component';
import { WorldBuildingComponent } from './srd/running-elixr/world-building/world-building.component';
import { PlayerDeathComponent } from './srd/running-elixr/player-death/player-death.component';
import { StatsService } from './services/stats.service';
import { TosComponent } from './tos/tos.component';
import { CommunityAgreementComponent } from './community-agreement/community-agreement.component';
import { WeaponsCharacteristicComponent } from './weapons/weapons-characteristic/weapons-characteristic.component';
import { CharacteristicCreatorComponent } from './characteristics/characteristic-creator/characteristic-creator.component';
import { CharacteristicTypePipe } from './pipes/characteristic-type.pipe';
import { LoginComponent } from './components/login/login.component';
import { UserSessionService } from 'app/services/user-session.service';

@NgModule({
  declarations: [
    AppComponent,
    IntroComponent,
    CreatureEditorComponent,
    CreatureDescriptionComponent,
    CreatureAbilitiesComponent,
    CreatureEnergyComponent,
    CreatureSpellSlotsComponent,
    CreatureDefenseComponent,
    CreatureItemsComponent,
    CreatureSpellsComponent,
    CreatureCharacteristicsComponent,
    CreatureAttacksComponent,
    MarkdownEditorComponent,
    CreatureWealthComponent,
    CreatureEquipmentComponent,
    CharacteristicsComponent,
    CharacteristicComponent,
    FeaturesComponent,
    RacesComponent,
    TemplatesComponent,
    TemplateComponent,
    SelectedCharacteristicDetailComponent,
    SrdArmorComponent,
    ArmorDetailComponent,
    ArmorComponent,
    WeaponsComponent,
    SrdWeaponsComponent,
    WeaponDetailComponent,
    SrdItemsComponent,
    ItemsComponent,
    ItemDetailComponent,
    SpellsComponent,
    SpellDetailComponent,
    MagicComponent,
    CreaturesComponent,
    CreatingACharacterComponent,
    BaseStatsComponent,
    CharacterDescriptionComponent,
    AbilitiesComponent,
    SkillsComponent,
    PlayingElixrComponent,
    RunningElixrComponent,
    EquipmentComponent,
    SrdCharacteristics,
    FlawsComponent,
    OathsComponent,
    CombatComponent,
    SocialInteractionComponent,
    ExplorationComponent,
    ActionsComponent,
    HealingComponent,
    CampaignsComponent,
    DungeonsComponent,
    WorldBuildingComponent,
    PlayerDeathComponent,
    TosComponent,
    CommunityAgreementComponent,
    WeaponsCharacteristicComponent,
    CharacteristicCreatorComponent,
    CharacteristicTypePipe,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
  ],
  providers: [
    ApiService,
    CreaturesService,
    CharacteristicService,
    TemplatesService,
    ArmorService,
    WeaponService,
    ElixrService,
    ItemService,
    SpellsService,
    MarkdownService,
    AppService,
    Title,
    StatsService,
    UserSessionService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
