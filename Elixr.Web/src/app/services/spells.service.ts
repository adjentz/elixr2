import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { ISpell  } from '../../models/view-models';

@Injectable()
export class SpellsService {

  constructor(private apiService: ApiService) { }

  searchSpells(name?:string): Promise<ISpell[]> {
    let input:ISearchSpellsInput = {
      name: name
    };
    return this.apiService.post("spells/search", input);
  }
}
interface ISearchSpellsInput {
  name: string
}
