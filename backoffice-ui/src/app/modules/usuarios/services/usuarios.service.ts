import {Injectable} from '@angular/core';
import {map, Observable, take} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {HttpUtil} from "../../../shared/utils/http.util";
import {environment} from "../../../../environments/environment.development";
import {Usuario} from "../models/usuario";
import {BaseResponse, Response} from "../../../shared/models/base/base-response";
import {CriarUsuarioRequest} from "../models/criar-usuario-request";

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(private httpClient: HttpClient) {
  }


  public getUsuarios(): Observable<Array<Usuario>> {
    return this.httpClient
      .get<Array<Usuario>>(`${environment.API_URL}auth/listar`)
      .pipe(
        take(1),
        map((result) => HttpUtil.extractData(result)),
      );
  }

  public desativarUsuario(idUsuario: string): Observable<Response> {
    return this.httpClient
      .put<Response>(`${environment.API_URL}Auth/desativar/${idUsuario}`, null)
      .pipe(
        take(1),
        map((result) => HttpUtil.extractData(result))
      );
  }


  public criarUsuario(criarUsuarioRequest: CriarUsuarioRequest): Observable<Response> {
    return this.httpClient
      .post<Response>(`${environment.API_URL}auth/cadastrar`, criarUsuarioRequest);
  }
}
