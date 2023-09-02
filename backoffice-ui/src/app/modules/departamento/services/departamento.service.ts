import {Inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {map, Observable, take} from "rxjs";
import {Colaborador, CriarDepartamentoRequest} from "../models/colaborador";
import {environment} from "../../../../environments/environment.development";
import {HttpUtil} from "../../../shared/utils/http.util";
import {Departamento} from "../models/departamento";

@Injectable({
  providedIn: 'root'
})
export class DepartamentoService {
  constructor(private httpClient: HttpClient) {
  }

  public getDepartamentos(): Observable<Array<Departamento>>{
    return this.httpClient
      .get<Array<Departamento>>(`${environment.API_URL}departamentos`)
      .pipe(
        take(1),
        map((result) => HttpUtil.extractData(result)),
      );
  }

  public getColaboradores(): Observable<Array<Colaborador>> {
    return this.httpClient
      .get<Array<Colaborador>>(`${environment.API_URL}pessoas/colaboradores`)
      .pipe(
        take(1),
        map((result) => HttpUtil.extractData(result)),
      );
  }

  public criarDepartamento(criarDepartamentoRequest: CriarDepartamentoRequest): Observable<Response> {
    return this.httpClient.post<Response>(`${environment.API_URL}departamentos`, criarDepartamentoRequest)
      .pipe(
        take(1),
        map((result) => HttpUtil.extractData(result))
      );
  }
}
