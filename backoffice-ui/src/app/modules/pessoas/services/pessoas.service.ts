import {Injectable} from '@angular/core';
import {map, Observable, take, tap} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {HttpUtil} from "../../../shared/utils/http.util";
import {environment} from "../../../../environments/environment.development";
import {
  PessoaFisica,
  PessoaFisicaModelRequest,
  PessoaJuridica,
  PessoaJuridicaModelRequest
} from "../models/pessoa-fisica.model";
import {PessoaJuridicaCriarComponent} from "../pages/pessoa-juridica-criar/pessoa-juridica-criar.component";

@Injectable({
  providedIn: 'root'
})
export class PessoasService {
  constructor(private httpClient: HttpClient) {
  }

  public getPessoasFisicas(): Observable<Array<PessoaFisica>> {
    return this.httpClient
      .get<Array<PessoaFisica>>(`${environment.API_URL}Pessoas/pessoas-fisicas`)
      .pipe(
        take(1),
        tap(result => console.log(result)),
        map((result) => HttpUtil.extractData(result)),
      );
  }

  public getPessoasJuridicas(): Observable<Array<PessoaJuridica>> {
    return this.httpClient
      .get<Array<PessoaJuridica>>(`${environment.API_URL}Pessoas/pessoas-juridicas`)
      .pipe(
        take(1),
        map((result) => HttpUtil.extractData(result)),
      );
  }

  public salvarPessoaFisica(request: PessoaFisicaModelRequest): Observable<Response> {
    return this.httpClient
      .post<Response>(`${environment.API_URL}Pessoas/pessoa-fisica`, request)
      .pipe(
        take(1),
        map((result) => HttpUtil.extractData(result)),
      );
  }

  public salvarPessoaJuridica(request: PessoaJuridicaModelRequest): Observable<Response> {
    return this.httpClient
      .post<Response>(`${environment.API_URL}Pessoas/pessoa-juridica`, request)
      .pipe(
        take(1),
        map((result) => HttpUtil.extractData(result)),
      );
  }
}
