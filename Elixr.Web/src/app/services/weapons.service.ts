import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { IWeapon  } from '../../models/view-models';

@Injectable()
export class WeaponService {

  constructor(private apiService: ApiService) { }

  searchWeapons(name?:string): Promise<IWeapon[]> {
    let input:ISearchWeaponsInput = {
      name: name
    };
    return this.apiService.post("weapons/search", input);
  }
}
interface ISearchWeaponsInput {
  name: string
}
