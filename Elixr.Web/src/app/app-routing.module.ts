import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IntroComponent } from './intro/intro.component';
import { CreatureEditorComponent } from './creature-editor/creature-editor.component';
import { FeaturesComponent } from './srd/features/features.component';
import { RacesComponent } from './srd/races/races.component';
import { SrdArmorComponent } from './srd/equipment/armor/srd-armor.component';
import { SrdWeaponsComponent } from './srd/equipment/srd-weapons/srd-weapons.component';
import { SrdItemsComponent } from './srd/equipment/srd-items/srd-items.component';
import { MagicComponent } from './srd/magic/magic.component';
import { CreaturesComponent } from './srd/creatures/creatures.component';


const routes: Routes = [
    { path: '', redirectTo: '/intro', pathMatch: 'full' },
    { path: 'intro', component: IntroComponent },
    { path: 'creature-editor', component: CreatureEditorComponent },
    { path: 'creature-editor/:creatureId', component: CreatureEditorComponent },
    { path: 'character-editor', component: CreatureEditorComponent, data: { isCharacter: true } },
    { path: 'character-editor/:creatureId', component: CreatureEditorComponent, data: { isCharacter: true } },
    { path: 'srd/features', component: FeaturesComponent },
    { path: 'srd/races', component: RacesComponent },
    { path: 'srd/equipment/armor', component: SrdArmorComponent },
    { path: 'srd/equipment/weapons', component: SrdWeaponsComponent },
    { path: 'srd/equipment/items', component: SrdItemsComponent },
    { path: 'srd/magic', component: MagicComponent },
    { path: 'srd/creatures', component: CreaturesComponent }
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
