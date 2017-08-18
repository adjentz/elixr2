import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { ITemplate } from '../../models/view-models';

@Injectable()
export class TemplatesService {

  constructor(private apiService: ApiService) { }

  searchTemplates(onlyRaces: boolean, name?: string): Promise<ITemplate[]> {
    let input: ISearchTemplatesInput = {
      name: name,
      onlyRaces: onlyRaces
    };
    return this.apiService.post("templates/search", input);
  }
  
}
export interface ISearchTemplatesInput {
  name: string,
  onlyRaces: boolean
}
