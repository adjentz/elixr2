import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { IItem  } from '../../models/view-models';

@Injectable()
export class ItemService {

  constructor(private apiService: ApiService) { }

  searchItems(name?:string): Promise<IItem[]> {
    let input:ISearchItemsInput = {
      name: name
    };
    return this.apiService.post("items/search", input);
  }
}
interface ISearchItemsInput {
  name: string
}
