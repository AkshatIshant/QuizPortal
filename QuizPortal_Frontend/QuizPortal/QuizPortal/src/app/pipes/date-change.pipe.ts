import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dateChange'
})
export class DateChangePipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
