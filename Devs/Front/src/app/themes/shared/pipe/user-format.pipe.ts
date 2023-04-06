import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'userFormat'
})
export class UserFormatPipe implements PipeTransform {

  transform(value: any, type: string): string {
    if (type === 'genre') {
      return value ? 'Homme' : 'Femme';
    } else if (type === 'role') {
      switch (value) {
        case 1: return 'ADMIN';
        case 2: return 'CLIENT';
        case 3: return 'USER';
        default: return 'INCONNU';
      }
    } else {
      return value;
    }
  }
}
