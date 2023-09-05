import {Pipe, PipeTransform} from "@angular/core";

@Pipe({
  name: 'formatoData'
})
export class FormatoDataPipe implements PipeTransform {

  transform(value: Date | string, ...args: unknown[]): unknown {
    const data = new Date(value);
    const dia = this.pad(data.getDate());
    const mes = this.pad(data.getMonth() + 1);
    const ano = data.getFullYear();
    return `${dia}/${mes}/${ano}`;
  }

  private pad(value: number) {
    if(value < 10) {
      return '0' + value;
    } else {
      return value.toString();
    }
  }
}



