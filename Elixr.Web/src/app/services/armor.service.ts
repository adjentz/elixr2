import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { IArmor  } from '../../models/view-models';

@Injectable()
export class ArmorService {

  constructor(private apiService: ApiService) { }

  searchArmor(name?:string): Promise<IArmor[]> {
    let input:ISearchArmorInput = {
      name: name
    };
    return this.apiService.post("armor/search", input);
  }
}
interface ISearchArmorInput {
  name: string
}
