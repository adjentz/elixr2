import { Component, OnInit } from '@angular/core';
import { CreaturesService, ICreatureListingViewModel } from '../../services/creatures.service';
import { ICreature } from '../../../models/view-models';


@Component({
  selector: 'app-creatures',
  templateUrl: './creatures.component.html',
  styleUrls: ['./creatures.component.css', '../../shared-styles/game-element.less']
})
export class CreaturesComponent implements OnInit {

  creatures:ICreatureListingViewModel[];

  constructor(private creaturesService:CreaturesService) { }

  async ngOnInit() {
    this.creatures = await this.creaturesService.getCreatures();
    console.log(this.creatures);
    
  }

}
