import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment.development";

@Injectable({
  providedIn: 'root'
})
export class ViaCepService {
  constructor(private httpClient: HttpClient) {
  }

  public getByCep(cep: string): Observable<ViaCepModel> {
    return this.httpClient.get<ViaCepModel>(`${environment.VIA_CEP_API_URL}${cep}${environment.VIA_CEP_API_TYPE}`);
  }
}

export class ViaCepModel {
  cep: string;
  logradouro: string;
  bairro: string;
  localidade: string;
  uf: string;
  ibge: string;
  ddd: string;
  siafi: string;
}
