import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { ICharacteristic, CharacteristicType } from '../../models/view-models';

@Injectable()
export class CharacteristicService {

  constructor(private apiService: ApiService) { }

  searchCharacteristics(type: CharacteristicType, name?: string): Promise<ICharacteristic[]> {
    let input: ISearchCharacteristicsInput = {
      name: name,
      type: type
    };
    return this.apiService.post("characteristics/search", input);
  }
}
interface ISearchCharacteristicsInput {
  name: string,
  type: CharacteristicType
}
