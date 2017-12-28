import { Pipe, PipeTransform } from '@angular/core';
import { CharacteristicType } from '../../models/view-models';
@Pipe({
  name: 'characteristicType'
})
export class CharacteristicTypePipe implements PipeTransform {

  transform(value: CharacteristicType, args?: any): string {
    switch (value) {
      case CharacteristicType.Feature:
        return 'Feature';
      case CharacteristicType.Flaw:
        return 'Flaw';
      case CharacteristicType.Oath:
        return 'Oath';
        default:
        return `Unknown Characteristic Type: ${value}`
    }
  }

}
